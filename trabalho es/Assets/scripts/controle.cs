using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class controle : MonoBehaviour
{
    
    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text feedBackmsg = null;
    [SerializeField]
    private Toggle remeberData = null;
    private int moeda;

    private string url = "http://192.168.1.57:888/login/login.php";
    private string url1 = "http://192.168.1.57:888/login/test.php"; 

    void Start()
    {
        if (PlayerPrefs.HasKey("lembra") && PlayerPrefs.GetInt("lembra")==1)
        {
            usuarioField.text = PlayerPrefs.GetString("rememberUser");
            senhaField.text = PlayerPrefs.GetString("rememberSenha");
        }
    }

    // Update is called once per frame
    public void FazerLogin()
    {
        if(usuarioField.text == "" || senhaField.text == ""){
            FeedBackErro("Preencha todos os campus");
        }else{
            string usuario = usuarioField.text;
            string senha = senhaField.text;

            if (remeberData.isOn)
            {
                PlayerPrefs.GetInt("lembra", 1);
                PlayerPrefs.SetString("rememberUser", usuario);
                PlayerPrefs.SetString("rememberSenha", senha);
            }
            WWW www = new WWW(url + "?login=" + usuario + "&senha=" + senha);
            StartCoroutine(ValidaLogin(www));
        }
    }
    IEnumerator ValidaLogin(WWW www){
        yield return www;       
        if(www.error == null){
            string b = www.text;
            int a = Convert.ToInt32(b);
            if(a == 1){
                FeedBackOk("Login realizado com sucesso\nCarregando o jogo...");
                string usuario = usuarioField.text;
                WWW www1 = new WWW(url1 + "?login=" + usuario);
                yield return www1; 
                
                
                string c = www1.text;
                int d = Convert.ToInt32(c);
                moeda = d;
                PlayerPrefs.SetInt("moeda", moeda);
                PlayerPrefs.SetString("nome", usuario);
                StartCoroutine(CarregaScane());
            }else{
                FeedBackErro("Usuário ou senha inválido");
            }
        }else{
            if(www.error == "couldn't connect to host"){
                FeedBackErro("Sevidor indisponível");
            }
        }
    }
    IEnumerator CarregaScane(){
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel ("inicio");
    }
    void FeedBackOk(string mensagem){
        feedBackmsg.CrossFadeAlpha(100f, 0f, false);
        feedBackmsg.color = Color.green;
        feedBackmsg.text = mensagem;
    }
    void FeedBackErro(string mensagem){
        feedBackmsg.CrossFadeAlpha(100f, 0f, false);
            feedBackmsg.color = Color.red;
            feedBackmsg.text = mensagem;
            feedBackmsg.CrossFadeAlpha(0f, 2f, false);
            usuarioField.text = "";
            senhaField.text = "";
    }

}

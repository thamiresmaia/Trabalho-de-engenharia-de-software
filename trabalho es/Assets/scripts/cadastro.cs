using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class cadastro : MonoBehaviour
{
    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text feedBackmsg = null;
    private int moeda;

    private int nota;
    private int pesos;
    private int media;
    

    private string url = "http://192.168.1.59:888/login/registro.php";
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void registro()
    {
        if(usuarioField.text == "" || senhaField.text == ""){
            FeedBackErro("Preencha todos os campus");
        }else{
            string usuario = usuarioField.text;
            WWW www = new WWW(url + "?login=" + usuario);
            StartCoroutine(ValidaRegistro(www));
            
        }
    }
    IEnumerator ValidaRegistro(WWW www){
        yield return www;
        if(www.error == null){
            string b = www.text;
            int a = Convert.ToInt32(b);
            if(a == 1){
                FeedBackErro("Usuário já cadastrado");
            }else{
                string usuario = usuarioField.text;
                string senha = senhaField.text;
                moeda = PlayerPrefs.GetInt("moeda");
                int cont;
                int[] notas = new int[20];
                for(cont = 0; cont < 20;cont++){
                    nota = PlayerPrefs.GetInt("notaFinal" + cont.ToString());
                    pesos = PlayerPrefs.GetInt("peso" + cont.ToString());
                    if(nota > 0){
                        media = nota / pesos;
                        nota = Mathf.RoundToInt(media);
                    }
                    
                    notas[cont] = nota;
                }
                www = new WWW(url + "?login=" + usuario + "&senha=" + senha + "&moeda=" + moeda + "&nota1=" + notas[0]);
                PlayerPrefs.SetString("nome", usuario);
                FeedBackOk("cadastrado Usuário...");
                StartCoroutine(CarregaScane());

            }
        }else{
            if(www.error == "couldn't connect to host"){
                FeedBackErro("Sevidor indisponível");
            }
        }
    }
    IEnumerator CarregaScane(){
        yield return new WaitForSeconds(2.0f);
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

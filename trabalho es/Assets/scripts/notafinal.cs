using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class notafinal : MonoBehaviour
{
    
    private int idTema;
    private int idNivel;

    public Text textNota;
    public Text infoNota;
    public Text infoGanho;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public Button imagem;
    public Button voltar;
    public Button menu;
    public Button refazer;

    private int notaF;
    private int notaF1;
    private float media;
    private int acertos;
    private int questoes1;
    private int pesos;
    private int moeda;
    private int moeda1;
    private int moeda2;
    private int m;
    private string usuario;

    

    private string url = "http:/192.168.1.57:888/login/aValores.php";

    void Start()
    {
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        imagem.interactable = false;
        usuario = PlayerPrefs.GetString("nome");
        infoGanho.text = PlayerPrefs.GetInt("m").ToString();
        moeda = PlayerPrefs.GetInt("moeda");
        idTema = PlayerPrefs.GetInt("idTema");
        if (idTema <= 2)
        {
            idNivel = 1;
        }
        else if(idTema<=4)
        {
            idNivel = 2;
        }
        else if(idTema<=6){
            idNivel = 3;
        }
        else if(idTema<=8){
            idNivel = 4;
        }
        else
        {
            idNivel = 5;
        }
        
        notaF = PlayerPrefs.GetInt("notaFinalTemp"+idTema.ToString());
        notaF1 = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertoTemp"+idTema.ToString());
        questoes1 = PlayerPrefs.GetInt("questoes" + idTema.ToString());
        pesos = PlayerPrefs.GetInt("peso" + idTema.ToString());

    
        media = notaF / pesos;
        notaF = Mathf.RoundToInt(media);

        media = notaF1 / pesos;
        notaF1 = Mathf.RoundToInt(media);
        if (notaF > 10) 
        {
            notaF = 10;
        }
        
        moeda1 = PlayerPrefs.GetInt("moeda2" + idTema.ToString());
        textNota.text = notaF.ToString();
        infoNota.text = acertos.ToString() + " DE " + questoes1.ToString() + " PERGUNTAS";
        
        if (notaF1 >= 5)
        {
            imagem.interactable = true;
        }
        if(idTema == 7){
            imagem.interactable = false;
        }
        else if(idTema == 8){
            imagem.interactable = false;
        }

        if (notaF == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
            
            if (moeda1 < 300)
            {
                moeda2 = 300;
                moeda1 = 300 - moeda1;
                m = moeda1;
                moeda += moeda1;
                infoGanho.text = moeda1.ToString();
                PlayerPrefs.SetInt("moeda", moeda);
                
                PlayerPrefs.SetInt("moeda2" + idTema.ToString(), moeda2);
                PlayerPrefs.SetInt("m" , m);
            }
            else 
            {
                m = 0;
                PlayerPrefs.SetInt("m", m);
                moeda += 0;
                PlayerPrefs.SetInt("moeda", moeda);
            }
            

        }
        else if (notaF >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
            
            if (moeda1 < 200)
            {
                moeda2 = 200;
                moeda1 = 200 - moeda1;
                m = moeda1;
                moeda += moeda1;
                infoGanho.text = moeda1.ToString();
                PlayerPrefs.SetInt("moeda", moeda);
                
                PlayerPrefs.SetInt("moeda2" + idTema.ToString(), moeda2);
                PlayerPrefs.SetInt("m", m);
            }
            else
            {
                m = 0;
                PlayerPrefs.SetInt("m", m);
                moeda += 0;
                PlayerPrefs.SetInt("moeda", moeda);
            }
        }
        else if (notaF >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
            
            if (moeda1 < 100)
            {
                moeda2 = 100;
                moeda1 = 100 - moeda1;
                moeda += moeda1;
                m = moeda1;
                infoGanho.text = moeda1.ToString();
                PlayerPrefs.SetInt("moeda", moeda);
                
                
                PlayerPrefs.SetInt("moeda2" + idTema.ToString(), moeda2);
                PlayerPrefs.SetInt("m", m);
            }
            else
            {
                m = 0;
                PlayerPrefs.SetInt("m", m);
                moeda += 0;
                PlayerPrefs.SetInt("moeda", moeda);
            }
        }
        else
        {
            m = 0;
            PlayerPrefs.SetInt("moeda", moeda);
        }
    }
    public void jogarImagem()
    {
        
        Application.LoadLevel("I" + idTema.ToString());
        
    }

    public void jogarNovamente()
    {
        
        Application.LoadLevel("T" + idTema.ToString()+ idNivel.ToString());
        
    }
    

}

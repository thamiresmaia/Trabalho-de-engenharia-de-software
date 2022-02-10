using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class forca : MonoBehaviour
{
   
    private int idTema;
    private int idNivel;
    private int notaF;
    private int idPalavra;
    private int erro = 0;
    private int acerto = 0;
    private int c = 0;

    public string[] palavras;
    public string[] palavras1;
    public string[] enigmas;

    public Text msm;
    public Text enigma;
    private string palavra;
    private string palavra2;
    private string palavra3;
    private string tela;
    public Button seguir;
    private char[] controle = new char[100];

    public GameObject cabeca;
    public GameObject braco1;
    
    public GameObject corpo;
    public GameObject pe1;
    

    public InputField letraField;
    public Text palavraSecreta;

    void Start()
    {
        idPalavra = 0;
        
        idTema = PlayerPrefs.GetInt("idTema");
        if (idTema <= 2)
        {
            idNivel = 1;
        }
        else if (idTema <= 4)
        {
            idNivel = 2;
        }
        else if (idTema <= 6)
        {
            idNivel = 3;
        }
        else if (idTema <= 8)
        {
            idNivel = 4;
        }
        else if (idTema <= 10)
        {
            idNivel = 5;
        }
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        enigma.text = enigmas[idTema - 1];
        palavra = palavras[idTema-1];
        palavra2 = palavras1[idTema - 1];
        palavra3 = " ";
        tela = "";
        int aux = palavra.Length;
        for (int i = 0; i < aux; i++)
        {
            if(palavra[i]==palavra3[0]){
                tela = tela + "  ";
                acerto++;
            }else{
                tela = tela + "_ ";
            }
            
        }
        palavraSecreta.text = tela;
        
        
        cabeca.SetActive(true);
        braco1.SetActive(false);
        corpo.SetActive(false);
        pe1.SetActive(false);
        seguir.interactable = false;
    }
    public void verificar()
    {
        
        if (erro < 3 && acerto <= palavra.Length) { 
            char letra = char.Parse(letraField.text);
            letra = char.ToUpper(letra);
            int cont = 0;
            string txt = "";
            int a = 0;
            int aux = palavra.Length;
            
            int aux1 = controle.Length;
            for (int j = 0; j < aux1; j++)
            {
                if (letra == controle[j])
                {
                    acerto--;
                }
            }
            for (int i = 0; i < aux; i++)
            {
                    if (letra == palavra[i])
                    {
                        controle[c] = palavra[i];
                        acerto++;
                        cont++;
                        txt = txt + palavra2[i] + " ";
                        a++;
                        c++;
                    }
                    else
                    {
                        txt = txt + tela[i + a] + " ";
                        a++;
                    }
            }
            
            tela = txt; 
            
            palavraSecreta.text = tela;
            if (cont==0)
            {
                erro++;
            }
            
        }
        letraField.text = "";
        if (acerto == palavra.Length)
        {
            msm.text = "Eita, se garantiu! Parabéns.";
            seguir.interactable = true;
            notaF += 10;
            if (notaF > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaF);
            }
            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaF);
        }
        if(erro == 1)
        {
            cabeca.SetActive(true);
            braco1.SetActive(false);
            
            corpo.SetActive(true);
            pe1.SetActive(false);
            
        }
        if (erro == 2)
        {
            cabeca.SetActive(true);
            braco1.SetActive(true);
            
            corpo.SetActive(true);
            pe1.SetActive(false);
            
        }
        if (erro == 3)
        {
            cabeca.SetActive(true);
            braco1.SetActive(true);
            
            corpo.SetActive(true);
            pe1.SetActive(true);
            
            seguir.interactable = true;
            msm.text = "Valha! Tente novamente!";
        }
    }
    public void jogarNovamente()
    {
        Application.LoadLevel("T" + idTema.ToString() + idNivel.ToString());
       
    }
    
}

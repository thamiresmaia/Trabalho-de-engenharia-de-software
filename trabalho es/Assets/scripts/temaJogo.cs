
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class temaJogo : MonoBehaviour
{
    public Button inicio;
    public Button seguir;

    public Text textTema;
    public Text textReceber;
    

    public GameObject placaTema;

    private int notaF;
    private int pesos;
    private int media;

    public string[] nomeTema;

    private int idTema;
    private int idTemaAux;
    public int idNivel;
    public int idNivelAux;
    public int totalT;
    private int moeda;

    private int acerto1;

    
    
    

    void Start()
    {
        PlayerPrefs.SetInt("idNivel", idNivel);
        
        inicio.interactable = false;
        seguir.interactable = false;
        textTema.text = "";
        moeda = PlayerPrefs.GetInt("moeda");
        textReceber.text = moeda.ToString();
        
        int acerto = 0;
        for (int i = 0; i < totalT; i++){
            idTemaAux = i+1;
            notaF = PlayerPrefs.GetInt("notaFinal" + idTemaAux.ToString());
            pesos = PlayerPrefs.GetInt("peso" + idTemaAux.ToString());
            media = notaF / pesos;
            notaF = Mathf.RoundToInt(media);
            if (notaF >= 5)
            {
                acerto++;
            }
        }
        
        
        if (acerto == totalT)
        {
            seguir.interactable = true;
            idNivelAux = idNivel;
            idNivelAux++;
        }

    }


    public void selecioneTema(int i)
    {
        idTema = i;
        textTema.text = nomeTema[idTema-1];
        inicio.interactable = true;
        if (idNivel == 2)
        {
            idTema += 2;
        }
        if (idNivel == 3)
        {
            idTema += 4;
        }
        if (idNivel == 4)
        {
            idTema += 6;
        }
        if (idNivel == 5)
        {
            idTema += 8;
        }
        PlayerPrefs.SetInt("idTema", idTema);
    }
    public void jogar()
    {
        Application.LoadLevel("introducao");

    }
    
    public void seguirTema()
    {
        Application.LoadLevel("temas" + idNivelAux.ToString() );
    }

}

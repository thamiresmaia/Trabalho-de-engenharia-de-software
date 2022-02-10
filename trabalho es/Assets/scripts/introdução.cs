using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introdução : MonoBehaviour
{
    public string[] frases;
    public Text frase;
    private int cont;
    private int idTema;
    private int idNivel;

    void Start()
    {
        idNivel = PlayerPrefs.GetInt("idNivel");
        idTema = PlayerPrefs.GetInt("idTema");
        
        frase.text = frases[idTema - 1];
    }
    public void seguir()
    {
        
        Application.LoadLevel("T" + idTema.ToString() + idNivel.ToString());
    }

    void Update()
    {
        
    }
}

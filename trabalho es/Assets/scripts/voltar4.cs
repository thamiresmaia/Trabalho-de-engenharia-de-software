using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltar4 : MonoBehaviour
{
    private int idNivel;
    private int idTema;
    void Start()
    {
        idNivel = PlayerPrefs.GetInt("idNivel"); 
        idTema = PlayerPrefs.GetInt("idTema");
    }
    public void v()
    {
        Application.LoadLevel("temas" + idNivel.ToString());
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.LoadLevel("temas"+idNivel.ToString());
    }
}

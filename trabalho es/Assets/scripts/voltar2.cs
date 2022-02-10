using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltar2 : MonoBehaviour
{
    private int idTema;
    private int idNivel;
    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        idNivel = PlayerPrefs.GetInt("idNivel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.LoadLevel("T"+ idTema.ToString() + idNivel.ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltar : MonoBehaviour
{
    public string nomeCena;

    
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.LoadLevel(nomeCena);
    }
}

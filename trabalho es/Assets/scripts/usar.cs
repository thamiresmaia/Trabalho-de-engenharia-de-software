using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usar : MonoBehaviour
{
    private int cont;

    public GameObject cena1;
    public GameObject cena2;
    void Start()
    {
        cont = PlayerPrefs.GetInt("cont");
        if(cont == 0)
        {
            cena1.SetActive(true);
            cena2.SetActive(false);
        }
        if (cont == 1)
        {
            cena2.SetActive(true);
            cena1.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }
}

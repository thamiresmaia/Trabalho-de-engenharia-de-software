using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
public class loja : MonoBehaviour
{
    public Text comprar1;
    public Text us;
    public Text us1;

    public Button c1;
    public Button u;
    public Button u1;

    private int moeda;
    private int cont=0;
    private int aux=0;
    void Start()
    {
        moeda = PlayerPrefs.GetInt("moeda");
        us.text = "USANDO";
        aux = PlayerPrefs.GetInt("aux");
        cont = PlayerPrefs.GetInt("cont");
        
        if (aux == 1){
            c1.interactable = false;
            comprar1.text = "COMPRADO";
            if (cont == 0)
            {
                u1.interactable = true;
                u.interactable = false;
                us.text = "USANDO";
                us1.text = "USAR";
            }
            if (cont == 1)
            {
                u1.interactable = false;
                u.interactable = true;
                us1.text = "USANDO";
                us.text = "USAR";
            }
        }
        else if (moeda>=1000) {
            c1.interactable = true;
        }
        else {
            u.interactable = false;
            us.text = "USANDO";
            c1.interactable = false;
            u1.interactable = false;
        }
        
    }
    public void comp1()
    {
        moeda -= 1000;
        PlayerPrefs.SetInt("moeda", moeda);
        comprar1.text = "COMPRADO";
        c1.interactable = false;
        u1.interactable = true;
        aux = 1;
        PlayerPrefs.SetInt("aux", aux);
        
    }
    public void usar()
    {
        cont = 0;
        u1.interactable = true;
        u.interactable = false;
        us.text = "USANDO";
        us1.text = "USAR";
        PlayerPrefs.SetInt("cont", cont);
        
    }

    public void usar1()
    {
        cont = 1;
        u1.interactable = false;
        u.interactable = true;
        us1.text = "USANDO";
        us.text = "USAR";
        PlayerPrefs.SetInt("cont", cont);
        
    }

    void Update()
    {
        
    }
}

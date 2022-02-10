using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Button volumeA;
    public Button volumeF;

    private int controle;
    public AudioSource musica;

    void Start()
    {

        musica = GetComponent<AudioSource>();
        controle = PlayerPrefs.GetInt("controle");
        if (controle == 0)
        {
            musica.Stop();
            volumeF.interactable = true;
            volumeA.interactable = false;
        }
        if (controle == 1)
        {

            musica.Play();
            volumeF.interactable = false;
            volumeA.interactable = true;
        }
        DontDestroyOnLoad(gameObject);
    }

    
}

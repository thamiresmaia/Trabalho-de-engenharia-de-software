using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;

public class audio : MonoBehaviour
{
    
    public Button volumeA;
    public Button volumeF;

    private int x;
    public AudioSource musica;
    void Start()
    {
        musica = GetComponent<AudioSource>();
        x = PlayerPrefs.GetInt("x");
        if (x == 1)
        {
            musica.Stop();
            volumeF.interactable = true;
            volumeA.interactable = false;
        }
        if (x == 0)
        {

            musica.Play();


            volumeF.interactable = false;
            volumeA.interactable = true;
        }
       
    }
    public void va()
    {
        volumeF.interactable = true;
        volumeA.interactable = false;
        x = 1;
        musica.Stop();
        PlayerPrefs.SetInt("x" , x);
    }
    public void vf()
    {
        volumeF.interactable = false;
        volumeA.interactable = true;
        x = 0;
        musica.Play();
        PlayerPrefs.SetInt("x", x);

    }
}

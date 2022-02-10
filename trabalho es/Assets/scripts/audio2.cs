using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;

public class audio2 : MonoBehaviour
{
    

    private int x;
    public AudioSource musica;
    void Start()
    {
        musica = GetComponent<AudioSource>();
        x = PlayerPrefs.GetInt("x");
        if (x == 1)
        {
            musica.Stop();
           
        }
        if (x == 0)
        {

            musica.Play();
            
        }
       
    }
    
}

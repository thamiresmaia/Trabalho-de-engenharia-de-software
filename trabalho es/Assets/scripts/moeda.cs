using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class moeda : MonoBehaviour
{
    public Text textReceber;
    private int moeda1;
    void Start()
    {
        moeda1 = PlayerPrefs.GetInt("moeda");
        textReceber.text = moeda1.ToString();
    }

    
}

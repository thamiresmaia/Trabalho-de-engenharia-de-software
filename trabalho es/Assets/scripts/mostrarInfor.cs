using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class mostrarInfor : MonoBehaviour
{
    
    private int acerto2;
    void Start()
    {
        for(int i = 1;i<=7;i++){
            if (PlayerPrefs.GetInt("notaFinal" + i.ToString())>=5)
            {
                acerto2++;
            }
        }
        PlayerPrefs.SetInt("acerto2", acerto2);

    }
}

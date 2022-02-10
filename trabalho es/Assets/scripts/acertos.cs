using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class acertos : MonoBehaviour
{
    private int auxInfor;
    public Text textInfor;
    void Start()
    {
        
        int auxInfor = PlayerPrefs.GetInt("acerto2");
        textInfor.text = auxInfor.ToString() + "/7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

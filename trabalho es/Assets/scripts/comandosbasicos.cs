using System.Collections;
using UnityEngine;

public class comandosbasicos : MonoBehaviour
{
    [System.Obsolete]
    public void carregaCena(string nomeCena)
    {
        Application.LoadLevel(nomeCena);
        
    }
    public void sair()
    {
        Application.Quit();
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temaInfo : MonoBehaviour
{
    public int idTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaF;
    private int pesos;
    private int media;



    // Start is called before the first frame update
    void Start()
    {
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        
        notaF = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        pesos = PlayerPrefs.GetInt("peso" + idTema.ToString());

        media = notaF / pesos; 
        notaF = Mathf.RoundToInt(media);
        if (notaF > 10)
        {
            notaF = 10;
        }

        if (notaF == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaF >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaF >= 5)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    }
    

}

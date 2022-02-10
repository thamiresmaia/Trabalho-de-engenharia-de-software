using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class responder : MonoBehaviour
{
    private int idTema;
    private int idNivel;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoPergunta;
    public Text infoPergunta1;

    public string[] perguntas;
    public string[] alterA;
    public string[] alterB;
    public string[] alterC;
    public string[] alterD;
    public string[] corretas;
    public string[] peso;

    private int idPergunta;

    private int acerto1;
    private int acerto;
    private int questoes;
    private float media1;
    private int notaFinal1;
    private int aux;
    private int aux1;

    

    
    void Start()
    {
        
        idTema = PlayerPrefs.GetInt("idTema");
        idNivel = PlayerPrefs.GetInt("idNivel");
        idPergunta = 0;
        questoes = perguntas.Length;
        PlayerPrefs.SetInt("questoes"+idTema.ToString(), questoes);
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alterA[idPergunta];
        respostaB.text = alterB[idPergunta];
        respostaC.text = alterC[idPergunta];
        respostaD.text = alterD[idPergunta];

        infoPergunta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas."; 
    }

    public void resposta(string alter)
    {
        
        if (alter == "A")
        {
            if (alterA[idPergunta] == corretas[idPergunta])
            {
                aux = int.Parse(peso[idPergunta]);
                aux *= 1;
                acerto1 += aux;
                acerto++;
                infoPergunta1.text = "você acertou a resposta anterior ";
            }
            else
            {
                infoPergunta1.text = "Você errou a resposta anterior ";
            }
        }
        else if (alter == "B")
        {
            if (alterB[idPergunta] == corretas[idPergunta])
            {
                aux = int.Parse(peso[idPergunta]);
                aux *= 1;
                acerto1 += aux;
                acerto++;
                infoPergunta1.text = "você acertou a resposta anterior ";
            }
            else
            {
                infoPergunta1.text = "Você errou a resposta anterior ";
            }
        }
        else if (alter == "C")
        {
            if (alterC[idPergunta] == corretas[idPergunta])
            {
                aux = int.Parse(peso[idPergunta]);
                aux *= 1;
                acerto1 += aux;
                acerto++;
                infoPergunta1.text = "você acertou a resposta anterior ";
            }
            else
            {
                infoPergunta1.text = "Você errou a resposta anterior ";
            }
        }
        else if (alter == "D")
        {
            if (alterD[idPergunta] == corretas[idPergunta])
            {
                aux = int.Parse(peso[idPergunta]);
                aux *= 1;
                acerto1 += aux;
                acerto++;
                infoPergunta1.text = "você acertou a resposta anterior ";

            }
            else
            {
                infoPergunta1.text = "Você errou a resposta anterior ";
            }
        }
        
        proximaPergunta();
    }
    void proximaPergunta()
    {
        
        aux1 += int.Parse(peso[idPergunta]);
        idPergunta += 1;
        if (idPergunta <= (questoes - 1))
        {
            idTema = PlayerPrefs.GetInt("idTema");
            questoes = perguntas.Length;
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alterA[idPergunta];
            respostaB.text = alterB[idPergunta];
            respostaC.text = alterC[idPergunta];
            respostaD.text = alterD[idPergunta];

            infoPergunta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questoes.ToString() + " perguntas.";
        }
        else
        { 
            Application.LoadLevel("F11");
            calcular();
        }

        
    }
    void calcular()
    {
        media1 = 10 * acerto1;
        notaFinal1 = (int)media1;
        

        if (notaFinal1 > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
        {
            
            PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal1);
            PlayerPrefs.SetInt("acerto" + idTema.ToString(), (int)acerto);
            

        }
        PlayerPrefs.SetInt("peso" + idTema.ToString(), aux1);
        PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal1);
        PlayerPrefs.SetInt("acertoTemp" + idTema.ToString(), (int)acerto);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main_Game_Screen : MonoBehaviour
{
    public static int ScoreValue;
    public static int acertos;
    public TMP_Text ScoreText;
    [SerializeField] TMP_Text tagText;
    [SerializeField] TMP_Text multiplicadorText;
    [SerializeField] TMP_Text comboText;
    [SerializeField] GameObject comboPanel;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("BackgroundTrack");
        ScoreValue = 0;
        acertos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreValue.ToString();
    }

    public void SetScore(int operador, bool acertou)
    {
        int ponto;
        float multiplicador;
        if (operador == 1 || operador == 2)
        {
            ponto = 70;
        }
        else
        {
            ponto = 100;
        }
        if (acertou)
        {
            comboText.text = "Combo de acertos: " + (acertos + 1).ToString();
            switch (acertos)
            {
                case 0:
                    multiplicador = 1.0f;
                    break;
                case 1:
                    comboPanel.SetActive(true);
                    multiplicadorText.text = "Pontos obtidos X1,2";
                    tagText.text = "Calculista";
                    multiplicador = 1.2f;
                    break;
                case 2:
                    comboPanel.SetActive(true);
                    multiplicadorText.text = "Pontos obtidos X1,3";
                    tagText.text = "Brilhante";
                    multiplicador = 1.3f;
                    break;
                default:
                    comboPanel.SetActive(true);
                    multiplicadorText.text = "Pontos obtidos X2,0";
                    tagText.text = "ALBERT EINSTEIN";
                    multiplicador = 2.0f;
                    break;
            }


            ScoreValue += (int)(ponto * multiplicador);
            acertos++;

            Debug.Log("Pontos: +" + ((int)(ponto * multiplicador)).ToString());
            Debug.Log("Acetos: " + acertos.ToString());
        }
        else
        {
            comboPanel.SetActive(false);
            ScoreValue -= ponto / 2;
            acertos = 0;
            if (ScoreValue < 0)
            {
                ScoreValue = 0;
            }

            Debug.Log("Pontos: -" + (ponto / 2).ToString());
            Debug.Log("Acetos: " + acertos.ToString());
        }
    }
}

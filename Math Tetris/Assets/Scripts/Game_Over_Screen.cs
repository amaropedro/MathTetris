using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Game_Over_Screen : MonoBehaviour

{
    //public TMP_Text score_value;
    public TMP_Text ScoreText;
    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("TelaDoJogo");
    }

    private void Start()
    {
        ScoreText.text = Main_Game_Screen.ScoreValue.ToString();

    }
}
    
   
    

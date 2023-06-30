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

        //score_value.text = UnityEngine.Random.Range(100, 200).ToString() + UnityEngine.Random.Range(100, 200).ToString();
        //ScoreText.text = Score._instance.ScoreValue.ToString();
        ScoreText.text = UnityEngine.Random.Range(100, 200).ToString() + UnityEngine.Random.Range(100, 200).ToString();

    }

    private void Update()
    {
        //ScoreText.text = Score._instance.ScoreValue.ToString();
    }


}
    
   
    

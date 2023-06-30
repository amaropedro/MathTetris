using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Main_Game_Screen : MonoBehaviour
{
    public static int ScoreValue;
    public TMP_Text ScoreText;

    void Start()
    {
        ScoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreValue.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;//ou é UIElements?
using UnityEngine.UIElements;


public class Score : MonoBehaviour
{
    public int ScoreValue;
    public TMP_Text ScoreText;

    public static Score _instance;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    /*void Start()
    {
        
    }

    // Update is called once per frame*/
    void Update()
    {
        ScoreText.text = ScoreValue.ToString();
    }
}

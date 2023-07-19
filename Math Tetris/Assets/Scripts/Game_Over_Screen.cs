using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Over_Screen : MonoBehaviour
{
    //public TMP_Text score_value;
    [SerializeField] RankHandler _rankHandler;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject rankUIElementsPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    private void OnEnable()//N�o entendi bem pra que serve isso
    {
        RankHandler.onRankListChanged += UpdateUI;
    }
    private void OnDisable()
    {
        RankHandler.onRankListChanged -= UpdateUI;
    }


    public TMP_Text ScoreText;
    [SerializeField] TMP_InputField nameInput;
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
        FindObjectOfType<AudioManager>().Stop("BackgroundTrack");
        FindObjectOfType<AudioManager>().Play("GameOver");
        ScoreText.text = Main_Game_Screen.ScoreValue.ToString();
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public void AddScore()
    {
        _rankHandler.AddRankIfPossible(new RankElement(nameInput.text.ToUpper(), Main_Game_Screen.ScoreValue));
        nameInput.text = "";
    }

    private void UpdateUI(List<RankElement> list)
    {
        for(int i =0; i < list.Count; i++)
        {
            RankElement rankAux = list[i];
            if (rankAux.score>0)
            {
                if (i >= uiElements.Count)
                {
                    //Intanciate new object entry
                    var inst = Instantiate(rankUIElementsPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    uiElements.Add(inst);
                }


                //Write or overwrite name and score
                var texts = uiElements[i].GetComponentsInChildren<TMP_Text>();
                texts[0].text = rankAux.playerName;
                texts[1].text = rankAux.score.ToString();
            }
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject sobrePanel;
    [SerializeField] GameObject TutorialPanel;

    public void play_game(){
	
		SceneManager.LoadScene("TelaDoJogo");

    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenSobrePanel() {
        sobrePanel.SetActive(true);
    }
    public void CloseSobrePanel()
    {
        sobrePanel.SetActive(false);
    }

    public void Quit_Game()
    {
        Debug.Log("QUIT !!!");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject sobrePanel;
    [SerializeField] GameObject mainMenu;

    public void play_game(){
	
		SceneManager.LoadScene("TelaDoJogo");

    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenSobrePanel() {
        sobrePanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void CloseSobrePanel()
    {
        sobrePanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit_Game()
    {
        Debug.Log("QUIT !!!");
        Application.Quit();
    }
}

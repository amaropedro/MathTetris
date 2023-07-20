using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   
    
	public void play_game(){
	
		SceneManager.LoadScene("TelaDoJogo");

    }

    public void startTutorial() {
        Game_Over_Screen.ShowPanel();
        //SceneManager.LoadScene("GameOverScreen.Game_Over_Screen.ShowPanel()");
    }

    public void AbrirTelaSobre() {
        SceneManager.LoadScene("TelaSobre");
    }

    public void Quit_Game()
    {
        Debug.Log("QUIT !!!");
        Application.Quit();
    }
}

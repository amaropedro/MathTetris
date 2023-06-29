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

    public void Quit_Game()
    {
        Debug.Log("QUIT !!!");
        Application.Quit();
    }
}

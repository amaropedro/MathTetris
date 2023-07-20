using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaSobre : MonoBehaviour
{
    public void voltarMenu() {
        print("cliquei");
        SceneManager.LoadScene("MainMenu");
    }
}

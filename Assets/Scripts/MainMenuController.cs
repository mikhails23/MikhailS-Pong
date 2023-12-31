using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame() {
        Debug.Log("Created By Mikhail Setyaprakasa");
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor() {
        Debug.Log("Created By Mikhail Setyaprakasa");
    }

    public void OpenCredit() {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}

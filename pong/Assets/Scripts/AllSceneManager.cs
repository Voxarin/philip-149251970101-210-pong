using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllSceneManager : MonoBehaviour
{
    public void toGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void toCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

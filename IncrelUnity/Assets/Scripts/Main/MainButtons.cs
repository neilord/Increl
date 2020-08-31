using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    public void ToGameScene()
    {
        StartGame.V_StartGame();
        Blinking.B_Stop = false;
    }
    public void ToShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ToTasksScene()
    {
        SceneManager.LoadScene("Tasks");
    }
    public void ToSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
}

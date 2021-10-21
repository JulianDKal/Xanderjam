using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartLevel(int levelIndex)
    {
        Game_Manager.instance.PlayLevel(levelIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }    

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToPrevScene()
    {
        SceneManager.UnloadSceneAsync("SettingsScene");
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("SettingsScene", LoadSceneMode.Additive);
    }

}

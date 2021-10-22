using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    FMOD.Studio.EventInstance selectInstance;

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

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        Game_Manager.instance.Resume();
    }

    public void PlaySelectSound()
    {
        selectInstance = FMODUnity.RuntimeManager.CreateInstance("event:/UI SFX/Menu - Level Select");
        selectInstance.start();
        selectInstance.release();
    }

}

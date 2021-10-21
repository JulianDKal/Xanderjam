using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public delegate void StopGame();
    public static event StopGame onGameOver;

    //private bool gameIsPaused;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void PlayLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
        if(onGameOver != null )onGameOver.Invoke();
    }

    public void Pause()
    {
        //gameIsPaused = true;
        SceneManager.LoadSceneAsync("Pause");
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //gameIsPaused = false;
        SceneManager.UnloadSceneAsync("Pause");
        Time.timeScale = 1;
    }
}

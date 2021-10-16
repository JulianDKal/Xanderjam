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


}

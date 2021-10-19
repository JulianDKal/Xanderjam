using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text levelDisplay;
    public int currentLevel = 1;
    public int selectedLevel = 1;
    public void Start()
    {
        levelDisplay.text = "Current Level: " + currentLevel.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Continue()
    {
        Debug.Log("Pressed Play: " + currentLevel);
    }
    public void Select()
    {
        if (currentLevel >= selectedLevel)
        {
            Debug.Log("Pressed Play: " + selectedLevel);
        }
        else
        {
            Debug.Log("No luck");
        }
    }
    //Level Selet functions, cause I can't think of any better way to do this
    public void Level1()
    {
        selectedLevel = 1;
    }
    public void Level2()
    {
        selectedLevel = 2;
    }
    public void Level3()
    {
        selectedLevel = 3;
    }
    public void Level4()
    {
        selectedLevel = 4;
    }
    public void Level5()
    {
        selectedLevel = 5;
    }
    public void Level6()
    {
        selectedLevel = 6;
    }
    public void Level7()
    {
        selectedLevel = 7;
    }
    public void Level8()
    {
        selectedLevel = 8;
    }
    public void Level9()
    {
        selectedLevel = 9;
    }
}

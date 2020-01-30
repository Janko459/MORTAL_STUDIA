using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void SpaceArena()
    {
        SceneManager.LoadScene(2);
    }
    public void ControlsPanel()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelPick()
    {
        SceneManager.LoadScene(4);
    }
    public void DLCLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Leave()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //[SerializeField] private string Menu;
    public void BackToMenu()
    {
        StartCoroutine("Game");
        
    }
    IEnumerator Game()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}

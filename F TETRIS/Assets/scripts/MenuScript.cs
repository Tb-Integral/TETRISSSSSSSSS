using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("tetris");
    }

    public void Exit_Game()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Останавливает режим игры в редакторе
        #endif
    }
}

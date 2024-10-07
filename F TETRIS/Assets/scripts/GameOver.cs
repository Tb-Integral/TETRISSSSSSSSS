using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _go;
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _black;

    public bool IsGameOver(Transform[,] grid)
    {
        for (int x = 0; x < tetramina_movement.width; x++)
        {
            if (grid[x, 18] != null)
            {
                Debug.Log("Game Over!");
                _go.SetActive(true);
                _menuButton.SetActive(true);
                _black.SetActive(true);
                return true;
            }
        }
        return false;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}

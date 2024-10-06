using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _go;

    public bool IsGameOver(Transform[,] grid)
    {
        for (int x = 0; x < tetramina_movement.width; x++)
        {
            if (grid[x, 18] != null)
            {
                Debug.Log("Game Over!");
                _go.SetActive(true);
                return true;
            }
        }
        return false;
    }
}

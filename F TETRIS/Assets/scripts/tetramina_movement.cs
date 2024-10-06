using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class tetramina_movement : MonoBehaviour
{
    [SerializeField] private Vector3 rotation_point;
    private float previousTime;
    [SerializeField] private float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    private ScoreManager scoreManager;

    void Start()
    {
        // Ищем ScoreManager один раз при старте
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!IsOutside())
                transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!IsOutside())
                transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), 90);
            if (!IsOutside())
                transform.RotateAround(transform.TransformPoint(rotation_point), new Vector3(0, 0, 1), -90);
        }
        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime / 7 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsOutside())
            {
                transform.position += new Vector3(0, 1, 0);
                AddToGrid();
                if (FindObjectOfType<GameOver>().IsGameOver(grid))
                {

                }
                else
                {
                    IsLineFull();
                    CheckTetrominoEmpty();
                    this.enabled = false;
                    FindObjectOfType<tetraminas_spawner>().spawn_tetramino();
                }
            }
            previousTime = Time.time;
        }  
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int childX = Mathf.CeilToInt(children.position.x);
            int childY = Mathf.CeilToInt(children.position.y);
            grid[childX, childY] = children;
        }

    }

    public bool IsOutside()
    {
        foreach (Transform children in transform)
        {
            int childX = Mathf.CeilToInt(children.position.x);
            int childY = Mathf.CeilToInt(children.position.y);

            if (childX < 0 || childX >= width || childY < 1)
            {
                return false;
            }

            if (childY < height && grid[childX, childY] != null) return false;
        }

        return true;
    }

    void IsLineFull()
    {
        for (int i = height-1; i >= 1; i--)
        {
            if (IsThatLineFull(i))
            {
                DeliteLine(i);
                DownLine(i);
            }
        }
    }

    bool IsThatLineFull(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        return true;
    }

    void DeliteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }

        if (scoreManager != null)
        {
            scoreManager.new_text(100); // Добавляем 100 очков за удаление строки
        }
    }
      
    void DownLine(int i)
    {
        for (int y=i; y < height; y++)
        {
            for(int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void CheckTetrominoEmpty()
    {
        // Находим все объекты с компонентом tetramina_movement
        tetramina_movement[] allTetrominoes = FindObjectsOfType<tetramina_movement>();

        // Проверяем каждую тетрамино
        foreach (var tetromino in allTetrominoes)
        {
            // Если у тетрамино нет дочерних объектов, уничтожаем её
            if (tetromino.transform.childCount == 0)
            {
                Destroy(tetromino.gameObject);
            }
        }
    }
}

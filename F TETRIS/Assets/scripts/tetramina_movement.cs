using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetramina_movement : MonoBehaviour
{
    [SerializeField] private Vector3 rotation_point;
    private float previousTime;
    [SerializeField] private float fallTime = 0.8f;
    public static int height = 9;
    public static int width = 4;
    private static Transform[,] grid = new Transform[width, height];

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
        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsOutside())
            {
                transform.position += new Vector3(0, 1, 0);
                //AddToGrid();
                this.enabled = false;
                FindObjectOfType<tetraminas_spawner>().spawn_tetramino();
            }
            previousTime = Time.time;
        }  
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int childX = Mathf.RoundToInt(children.position.x);
            int childY = Mathf.RoundToInt(children.position.y);

            grid[childX, childY] = children;
        }

    }

    bool IsOutside()
    {
        foreach (Transform children in transform)
        {
            int childX = Mathf.RoundToInt(children.position.x);
            int childY = Mathf.RoundToInt(children.position.y);

            if (childX < -4 || childX > 4 || childY < -9)
            {
                return false;
            }

            //if (grid[childX, childY] != null) return false;
        }

        return true;
    }
}

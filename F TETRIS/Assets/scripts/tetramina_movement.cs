using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetramina_movement : MonoBehaviour
{

    private float previousTime;
    [SerializeField] private float fallTime = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-0.95f, 0, 0);
            if (!IsOutside())
                transform.position += new Vector3(+0.95f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(0.95f, 0, 0);
            if (!IsOutside())
                transform.position += new Vector3(-0.95f, 0, 0);
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -0.95f, 0);
            previousTime = Time.time;
            if (!IsOutside())
            {
                transform.position += new Vector3(0, +0.95f, 0);
            }
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
        }

        return true;
    }
}

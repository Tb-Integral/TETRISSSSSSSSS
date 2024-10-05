using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashOut : MonoBehaviour
{
    static public void TrashCheck(Transform transform)
    {
        foreach(Transform t in transform)
        {
            if (t.childCount == 0)
            {
                Destroy(transform);
            }
        }
    }
}

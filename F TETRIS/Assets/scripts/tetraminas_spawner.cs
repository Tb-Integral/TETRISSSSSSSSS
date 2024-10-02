using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class tetraminas_spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _tetraminas;

    private void Start()
    {
        Instantiate(_tetraminas[Random.Range(0, _tetraminas.Length)], transform.position, Quaternion.identity);
    }

    public void spawn_tetramino()
    {
        Instantiate(_tetraminas[Random.Range(0, _tetraminas.Length)], transform.position, Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class tetraminas_spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _tetraminas;
    public Transform tetrominoContainer;

    private void Start()
    {
        GameObject tetramino =Instantiate(_tetraminas[Random.Range(0, _tetraminas.Length)], transform.position, Quaternion.identity);
        tetramino.transform.SetParent(tetrominoContainer);
    }

    public void spawn_tetramino()
    {
        GameObject tetramino = Instantiate(_tetraminas[Random.Range(0, _tetraminas.Length)], transform.position, Quaternion.identity);
        tetramino.transform.SetParent(tetrominoContainer);
    }
}
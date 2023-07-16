using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _spawnInterval = 1f;
    [SerializeField]
    private int _countEnemy = 10;

    private float _lastGeneration;

    private void Start()
    {
        _lastGeneration = Time.time;
    }

    private void Update()
    {
        if (Time.time - _lastGeneration >= _spawnInterval && _countEnemy > 0)
        {
            _lastGeneration += _spawnInterval;
            SpawnObject();
            _countEnemy--;
        }

    }

    private void SpawnObject()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
    }
}

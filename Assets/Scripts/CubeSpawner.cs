using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeFactory))]
[RequireComponent(typeof(ColorChanger))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    [SerializeField] private Player _player;

    [SerializeField] private float _minCount = 2;
    [SerializeField] private float _maxCount = 6;

    [SerializeField] private float _scaleReductionFactor = 2;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _chanceSuccess = 1;
    [SerializeField] private float _chanceReductionRatio = 2;

    private CubeFactory _cubeFactory;
    private ColorChanger _colorChanger;

    public event Action<List<Rigidbody>, Vector3> Spawned;
    
    private void Start()
    {
        _cubeFactory = GetComponent<CubeFactory>();
        _colorChanger = GetComponent<ColorChanger>();
    }

    private void OnEnable()
    {
        _player.Destroyed += Spawn;
    }

    private void OnDisable()
    {
        _player.Destroyed -= Spawn;
    }

    private void Spawn(Vector3 spawnPoint, Vector3 scale)
    {
        if (CanCreate())
        {
            float randomCount = UnityEngine.Random.Range(_minCount, _maxCount);
            randomCount = Mathf.RoundToInt(randomCount);

            List<Rigidbody> spawnedCubes = _cubeFactory.Create(_prefabCube, spawnPoint, scale, _colorChanger, randomCount, _scaleReductionFactor);

            Spawned?.Invoke(spawnedCubes, spawnPoint);

            _chanceSuccess /= _chanceReductionRatio;
        }
    }

    private bool CanCreate()
    {
        float randomChance = UnityEngine.Random.value;

        if (randomChance < _chanceSuccess)
            return true;
        else
            return false;
    }
}

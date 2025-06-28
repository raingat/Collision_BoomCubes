using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detonator))]
[RequireComponent(typeof(CubeSpawner))]
public class CubeController : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private float _minCount = 2;
    [SerializeField] private float _maxCount = 6;

    private CubeSpawner _cubeSpawner;
    private Detonator _detonator;

    private void Start()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _detonator = GetComponent<Detonator>();
    }

    private void OnEnable()
    {
        _player.ClickedOnCube += Split;
    }

    private void OnDisable()
    {
        _player.ClickedOnCube -= Split;
    }

    private void Split(Cube cube)
    {
        if (cube.CanSplit())
        {
            int randomCountAfterSplit = Mathf.RoundToInt(Random.Range(_minCount, _maxCount));

            List<Rigidbody> rigidbodys = _cubeSpawner.Spawn(cube, randomCountAfterSplit);

            _detonator.Explode(rigidbodys, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}

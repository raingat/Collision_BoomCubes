using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCube;

    [SerializeField] private Player _player;

    [SerializeField] private float _minCount = 2;
    [SerializeField] private float _maxCount = 6;

    [SerializeField] private float _scaleReductionFactor = 2;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _chanceSuccess = 1;
    [SerializeField] private float _chanceReductionRatio = 2;

    private void OnEnable()
    {
        _player.Destroyed += Create;
    }

    private void OnDisable()
    {
        _player.Destroyed -= Create;
    }

    private void Create(Vector3 spawnPoint, Vector3 scale)
    {
        if (CanCreate())
        {
            float randomCount = Random.Range(_minCount, _maxCount);
            randomCount = Mathf.RoundToInt(randomCount);

            for (int i = 0; i < randomCount; i++)
            {
                Color color = Random.ColorHSV();

                GameObject gameObject = Instantiate(_prefabCube, spawnPoint, Quaternion.identity);

                gameObject.GetComponent<Transform>().localScale = scale / _scaleReductionFactor;

                gameObject.GetComponent<Renderer>().material.color = color;

                gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000f, spawnPoint, 1000f);
            }

            _chanceSuccess /= _chanceReductionRatio;
        }
    }

    private bool CanCreate()
    {
        float randomChance = Random.value;

        if (randomChance < _chanceSuccess)
            return true;
        else
            return false;
    }
}

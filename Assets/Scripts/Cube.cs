using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _chanceSpawnSuccess = 1;
    [SerializeField] private float _chanceSpawnReductionRatio = 2;

    public float ChanceSuccess => _chanceSpawnSuccess;

    public bool CanSplit()
    {
        float randomChance = Random.value;

        if (randomChance < _chanceSpawnSuccess)
            return true;
        else
            return false;
    }

    public void DecreaseChanceSpawn(float currentChance)
    {
        _chanceSpawnSuccess = currentChance / _chanceSpawnReductionRatio;
    }
}

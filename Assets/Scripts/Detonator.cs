using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private float _explosionRadius = 1000f;
    private float _explosionForce = 1000f;

    private void OnEnable()
    {
        _cubeSpawner.Spawned += Explode;
    }

    private void OnDisable()
    {
        _cubeSpawner.Spawned -= Explode;
    }

    public void Explode(List<Rigidbody> rigidbodys, Vector3 explosionPoint)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius);
        }
    }
}

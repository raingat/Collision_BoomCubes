using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _explosionRadius = 1000f;
    private float _explosionForce = 1000f;

    public void Explode(List<Rigidbody> rigidbodys, Vector3 explosionPoint)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius);
        }
    }
}

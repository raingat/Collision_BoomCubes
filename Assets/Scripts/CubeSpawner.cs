using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _scaleReductionFactor = 2;

    private ColorChanger _colorChanger;

    private void Start()
    {
        _colorChanger = GetComponent<ColorChanger>();
    }

    public List<Rigidbody> Spawn(GameObject cube, int count)
    {
        List<Rigidbody> rigidbodys = new List<Rigidbody>();

        for (int i = 0; i < count; i++)
        {
            GameObject partCube = Instantiate(cube, cube.transform.position, Quaternion.identity);

            partCube.GetComponent<Cube>().DecreaseChanceSpawn(cube.GetComponent<Cube>().ChanceSuccess);

            partCube.transform.localScale /= _scaleReductionFactor;

            _colorChanger.Change(partCube.GetComponent<Renderer>());

            rigidbodys.Add(partCube.GetComponent<Rigidbody>());
        }

        return rigidbodys;
    }
}

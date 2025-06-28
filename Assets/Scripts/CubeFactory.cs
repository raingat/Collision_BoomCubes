using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    public List<Rigidbody> Create(GameObject prefabCube, Vector3 position, Vector3 scale, ColorChanger colorChanger, float countObject, float scaleReductionFactor)
    {
        List<Rigidbody> cubes = new List<Rigidbody>();

        for (int i = 0; i < countObject; i++)
        {
            GameObject cube = Instantiate(prefabCube, position, Quaternion.identity);

            cube.transform.localScale = scale / scaleReductionFactor;

            colorChanger.Change(cube.GetComponent<Renderer>());

            cubes.Add(cube.GetComponent<Rigidbody>());
        }

        return cubes;
    }
}

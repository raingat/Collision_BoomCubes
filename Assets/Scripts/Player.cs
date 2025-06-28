using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMaskIgnore;

    private int _numberLeftMouseButton = 0;

    private Ray _ray;
    private RaycastHit _hitInfo;

    public event Action<GameObject> ClickedOnCube;

    private void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitInfo, Mathf.Infinity, ~_layerMaskIgnore))
        {
            if (Input.GetMouseButtonDown(_numberLeftMouseButton))
            {
                ClickedOnCube?.Invoke(_hitInfo.transform.gameObject);
            }
        }
    }
}

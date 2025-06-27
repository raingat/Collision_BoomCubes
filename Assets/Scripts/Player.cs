using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMaskIgnore;

    private int _numberLeftMouseButton = 0;

    private Ray _ray;
    private RaycastHit _hitInfo;

    public event Action<Vector3, Vector3> Destroyed;

    private void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hitInfo, Mathf.Infinity, ~_layerMaskIgnore))
        {
            if (Input.GetMouseButtonDown(_numberLeftMouseButton))
            {
                Vector3 positionObject = _hitInfo.transform.position;

                Vector3 scaleObject = _hitInfo.transform.localScale;

                Destroy(_hitInfo.transform.gameObject);
                
                Destroyed?.Invoke(positionObject, scaleObject);
            }
        }
    }
}

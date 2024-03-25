using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    private Vector3 mouseWorldPoint;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        print(Input.mousePosition);
        transform.position = mouseWorldPoint;
    }
}



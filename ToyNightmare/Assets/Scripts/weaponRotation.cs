using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponRotation : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    Vector3 mouseWorldPoint;

    [HideInInspector] public Vector3 direction;
    private float directionLeght;


    private Transform shootBasePoint;

    private void Start()
    {
        shootBasePoint = GameObject.Find("ShootBasePoint").transform;
    }

    private void FixedUpdate()
    {
        calculateWeaponRotation();
    }

    private void calculateWeaponRotation()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        direction = (mouseWorldPoint - shootBasePoint.position);
        directionLeght = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2));
        
        if(directionLeght > 0.25f)
        {
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(90, 0, angle);
        }
        
    }
}

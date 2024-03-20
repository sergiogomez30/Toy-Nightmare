using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;

    private playerMovement scriptMovement;

    private void Start()
    {
        scriptMovement = GetComponentInParent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptMovement.dimension == 2 && !scriptMovement.dashing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Vector3 fireballRotation = new Vector3(90, 0, firePoint.rotation.z);
                Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}

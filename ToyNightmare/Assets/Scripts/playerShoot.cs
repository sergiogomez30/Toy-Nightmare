using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;

    private playerMovement scriptMovement;

    public GameObject weaponSystem;
    private Animator weaponSystemAnimator;

    private bool shooting;

    private void Start()
    {
        scriptMovement = GetComponentInParent<playerMovement>();
        weaponSystemAnimator = weaponSystem.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSystemAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil"))
        {
            shooting = true;
        }
        else shooting = false;

        if (scriptMovement.dimension == 2 && !scriptMovement.dashing && !shooting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
                weaponSystemAnimator.SetTrigger("Shoot");
            }
        }
    }
}

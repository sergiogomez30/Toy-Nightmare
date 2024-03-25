using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    private Transform shootPoint;

    private playerMovement scriptMovement;

    private GameObject weaponSystem;
    private Animator weaponSystemAnimator;

    private Animator shootEffectAnimator;

    private void Start()
    {
        shootPoint = GameObject.Find("ShootPoint").transform;
        weaponSystem = GameObject.Find("WeaponSystem");
        scriptMovement = GetComponentInParent<playerMovement>();
        weaponSystemAnimator = weaponSystem.GetComponent<Animator>();
        shootEffectAnimator = GameObject.Find("ShootEffect").GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        if (scriptMovement.dimension == 2 && !scriptMovement.dashing && !weaponSystemAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil"))
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
                weaponSystemAnimator.SetTrigger("Shoot");
                shootEffectAnimator.SetTrigger("Shoot");
            }
        }
    }
}

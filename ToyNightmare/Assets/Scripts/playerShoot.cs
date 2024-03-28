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

    private AudioSource shootEffectAudioSource;
    public AudioClip shootAudioEffect;
    private float randomPitch;
    public float minPitch;
    public float maxPitch;

    public int munition;
    private bool reloading;
    public float reloadTime;
    private float reloadTimer;

    private Animator weaponAnimator;

    private void Start()
    {
        shootPoint = GameObject.Find("ShootPoint").transform;
        weaponSystem = GameObject.Find("WeaponSystem");
        scriptMovement = GetComponentInParent<playerMovement>();
        weaponSystemAnimator = weaponSystem.GetComponent<Animator>();
        shootEffectAnimator = GameObject.Find("ShootEffect").GetComponent<Animator>();
        shootEffectAudioSource = GameObject.Find("ShootSound").GetComponent<AudioSource>();

        munition = 8;
        weaponAnimator = GameObject.Find("Weapon").GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        shoot();
        Reload();
    }


    void shoot()
    {
        if (scriptMovement.dimension == 2 && !scriptMovement.dashing && !weaponSystemAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil") && !reloading)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
                weaponSystemAnimator.SetTrigger("Shoot");
                shootEffectAnimator.SetTrigger("Shoot");

                randomPitch = Random.Range(minPitch, maxPitch);
                shootEffectAudioSource.pitch = randomPitch;
                shootEffectAudioSource.PlayOneShot(shootAudioEffect);

                munition--;
                if (munition <= 0)
                {
                    reloadTimer = 0;
                    reloading = true;
                    weaponAnimator.SetTrigger("Reloading");
                }
            }
        }
    }

    private void Reload()
    {
        if(reloading)
        {
            if (!scriptMovement.dashing)
            {
                reloadTimer += Time.deltaTime;
            }

            if (reloadTimer >= reloadTime)
            {
                munition = 8;
                reloading = false;
            }
        }
    }
}

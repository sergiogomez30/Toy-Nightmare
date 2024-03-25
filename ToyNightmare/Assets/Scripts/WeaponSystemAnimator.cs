using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystemAnimator : MonoBehaviour
{
    private Animator weaponSystemAnimator;

    void Start()
    {
        weaponSystemAnimator = GetComponent<Animator>();
        weaponSystemAnimator.keepAnimatorStateOnDisable = true;
    }
}

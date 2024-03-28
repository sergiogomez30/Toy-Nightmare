using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAnimatorsState : MonoBehaviour
{
    public Animator weaponSystemAnimator;
    public Animator WeaponAnimator;

    void Start()
    {
        weaponSystemAnimator.keepAnimatorStateOnDisable = true;
        WeaponAnimator.keepAnimatorStateOnDisable = true;
    }
}

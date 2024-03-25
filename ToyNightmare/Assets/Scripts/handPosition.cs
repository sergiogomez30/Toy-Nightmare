using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handPosition : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    private Vector3 mouseWorldPoint;

    private Transform weaponSystemTransform;

    [HideInInspector] public Vector3 direction;

    private Vector3 leftweaponSystemTransform;
    private Vector3 rightweaponSystemTransform;

    private GameObject weapon;
    private SpriteRenderer rendWeapon;

    private GameObject hand;
    private SpriteRenderer rendHand;

    private ShootPosition scriptShootBasePointPosition;
    private ShootPosition scriptShootEffect;

    void Start()
    {
        weaponSystemTransform = GameObject.Find("WeaponSystem").transform;
        weapon = GameObject.Find("Weapon");
        hand = GameObject.Find("Hand");

        leftweaponSystemTransform = new Vector3(-weaponSystemTransform.localPosition.x, weaponSystemTransform.localPosition.y, 0);
        rightweaponSystemTransform = new Vector3(weaponSystemTransform.localPosition.x, weaponSystemTransform.localPosition.y, 0);

        rendWeapon = weapon.GetComponent<SpriteRenderer>();
        rendHand = hand.GetComponent<SpriteRenderer>();

        scriptShootBasePointPosition = GameObject.Find("ShootBasePoint").GetComponent<ShootPosition>();
        scriptShootEffect = GameObject.Find("ShootEffect").GetComponent<ShootPosition>();
    }

    private void FixedUpdate()
    {
        calculateHandPosition();
        
    }

    private void calculateHandPosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        direction = (mouseWorldPoint - transform.position);
        //print(direction.x);

        if (direction.x <= 0f)
        {
            weaponSystemTransform.localPosition = leftweaponSystemTransform;
            rendWeapon.flipY = true;
            rendHand.flipY = true;
        }
        else
        {
            weaponSystemTransform.localPosition = rightweaponSystemTransform;
            rendWeapon.flipY = false;
            rendHand.flipY = false;
        }

        scriptShootBasePointPosition.fixPosition(direction);
        scriptShootEffect.fixPosition(direction);
    }
}

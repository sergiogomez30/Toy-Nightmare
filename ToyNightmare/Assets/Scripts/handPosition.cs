using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handPosition : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    Vector3 mouseWorldPoint;

    public Transform weaponSystemTransform;

    [HideInInspector] public Vector3 direction;

    private Vector3 initialLeftweaponSystemTransform;
    private Vector3 initialRightweaponSystemTransform;
    

    private Vector3 leftweaponSystemTransform;
    private Vector3 rightweaponSystemTransform;

    public GameObject weaponSystem;
    private Animator weaponSystemTransformAnimator;

    public GameObject weapon;
    private SpriteRenderer rendWeapon;

    public GameObject hand;
    private SpriteRenderer rendHand;

    private FirePointPosition scriptFirePointPosition;
    void Start()
    {
        initialLeftweaponSystemTransform = new Vector3(-weaponSystemTransform.localPosition.x, weaponSystemTransform.localPosition.y, 0);
        initialRightweaponSystemTransform = new Vector3(weaponSystemTransform.localPosition.x, weaponSystemTransform.localPosition.y, 0);
        weaponSystemTransformAnimator = weaponSystemTransform.GetComponent<Animator>();

        rendWeapon = weapon.GetComponent<SpriteRenderer>();
        rendHand = hand.GetComponent<SpriteRenderer>();

        scriptFirePointPosition = GameObject.Find("firePoint").GetComponent<FirePointPosition>();
    }

    private void FixedUpdate()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        direction = (mouseWorldPoint - transform.position);
        //print(direction.x);

        leftweaponSystemTransform = initialLeftweaponSystemTransform;
        rightweaponSystemTransform =  initialRightweaponSystemTransform;

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

        scriptFirePointPosition.fixFirePointPosition(direction);
    }
}

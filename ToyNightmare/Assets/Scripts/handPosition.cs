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


    void Start()
    {
        initialLeftweaponSystemTransform = new Vector3(-weaponSystemTransform.position.x, weaponSystemTransform.position.y, weaponSystemTransform.position.z);
        initialRightweaponSystemTransform = new Vector3(weaponSystemTransform.position.x, weaponSystemTransform.position.y, weaponSystemTransform.position.z);
        weaponSystemTransformAnimator = weaponSystemTransform.GetComponent<Animator>();

        rendWeapon = weapon.GetComponent<SpriteRenderer>();
        rendHand = hand.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        leftweaponSystemTransform = transform.position + initialLeftweaponSystemTransform;
        rightweaponSystemTransform = transform.position + initialRightweaponSystemTransform;

        if (direction.x <= 0)
        {
            rendWeapon.flipY = true;
            rendHand.flipY = true;

        }
        else
        {
            rendWeapon.flipY = false;
            rendHand.flipY = false;
        }
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

        if(!weaponSystemTransformAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil")) //si no se está ejecutando la animación de disparo
        {
            if (direction.x < 0f)
            {
                weaponSystemTransform.position = leftweaponSystemTransform;
            }
            else
            {
                weaponSystemTransform.position = rightweaponSystemTransform;
            }
        }
    }
}

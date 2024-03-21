using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handPosition : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    Vector3 mouseWorldPoint;

    public Transform hand;

    private Vector3 initialLeftHand;
    private Vector3 initialRightHand;
    [HideInInspector] public Vector3 direction;

    private Vector3 leftHand;
    private Vector3 rightHand;

    public GameObject weaponSystem;
    private Animator weaponSystemAnimator;
    private AnimatorStateInfo stateInfo;
    private AnimatorClipInfo clip;
    

    void Start()
    {
        initialLeftHand = new Vector3(-hand.position.x, hand.position.y, hand.position.z);
        initialRightHand = new Vector3(hand.position.x, hand.position.y, hand.position.z);
        weaponSystemAnimator = weaponSystem.GetComponent<Animator>();
    }

    private void Update()
    {
        leftHand = transform.position + initialLeftHand;
        rightHand = transform.position + initialRightHand;
    }


    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        direction = (mouseWorldPoint - transform.position);
        print(direction.x);

        if (!weaponSystemAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil")) //si no se está ejecutando la animación de disparo
        {
            if (direction.x < 0f)
            {
                hand.position = leftHand;
            }
            else
            {
                hand.position = rightHand;
            }
        }
    }
}

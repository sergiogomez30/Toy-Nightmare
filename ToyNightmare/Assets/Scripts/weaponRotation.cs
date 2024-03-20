using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponRotation : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    Vector3 mouseWorldPoint;

    private Animator playerAnimator;
    [HideInInspector] public float direction_x;
    [HideInInspector] public float direction_z;

    private SpriteRenderer rend;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask)) 
        {
            //Debug.DrawRay(ray.origin, ray.direction * 30f);
            mouseWorldPoint = raycastHit.point;
        }
        
        Vector3 direction = (mouseWorldPoint - transform.position).normalized;
        direction_x = direction.x;
        direction_z = direction.z;
        print(direction_z);
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        if(direction.z <= 0.37f)
        {
            rend.sortingOrder = 4;
        }
        else
        {
            rend.sortingOrder = 2;
        }

        transform.eulerAngles = new Vector3(90, 0, angle);
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        print(mouseWorldPoint);
        Vector3 direction = (mouseWorldPoint - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(90, 0, angle);
    }*/

    //print(direction);
    /*float anglee = Mathf.Acos(direction.x / Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2))) * Mathf.Rad2Deg;
    if (direction.z < 0)
    {
        anglee *= -1;
    }*/

    //transform.eulerAngles = new Vector3(0, angle, 0);

    //direction.y = 0;
    //transform.right = direction;
    //transform.eulerAngles = new Vector3(90, 0, direction.z);
    //transform.Rotate(new Vector3(0, 0, angle) * Time.deltaTime);


    //transform.right = new Vector3(mouseWorldPoint.x, 0, 0);
    //Vector3 finalDirection = new Vector3(0, 0, direction.z);
    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //transform.LookAt(new Vector3(transform.position.x, transform.position.y, direction.z));
    //transform.eulerAngles.x = 0;
}

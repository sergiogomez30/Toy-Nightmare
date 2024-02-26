using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public float dashTime;
    [HideInInspector] public bool dashing;
    private bool isMoving;
    [HideInInspector] public int dimension;

    private float horizontal;
    private float vertical;
    private Vector3 movementDirection;

    ChangeDimension scriptDimension;

    private Animator playerAnimator;

    private float dashTimer;

    private void Start()
    {
        dashing = false;
        dimension = 2;
        scriptDimension = this.GetComponent<ChangeDimension>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        dash();
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        if (!dashing)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); //GetAxisRaw elimina la progresión de movimiento (antes utilizaba GetAxis)
            vertical = Input.GetAxisRaw("Vertical");
        }

    
        if (dimension == 2) //cambian los controles dependiendo de la dimension
        {
            //if (!dashing) //la trayectoria del dash será la misma aunque se cambie de dimension en medio de la misma
            //{
                movementDirection = new Vector3(horizontal, 0, vertical).normalized;
            //}
        }
        else
        {
            //if (!dashing) //la trayectoria del dash será la misma aunque se cambie de dimension en medio de la misma
            //{
                movementDirection = new Vector3(vertical, 0, -horizontal).normalized;
            //}
        }
        
        
        isMoving = movementDirection != new Vector3(0, 0, 0);

        playerAnimator.SetFloat("Horizontal", horizontal);
        playerAnimator.SetFloat("Vertical", vertical);
        playerAnimator.SetFloat("Speed", movementDirection.sqrMagnitude);

        //Mueve al jugador
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    }

    public void dash()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!dashing && isMoving && scriptDimension.canDash)
            {
                dashing = true;
                dashTimer = 0;
                speed += dashSpeed;
                playerAnimator.SetBool("isRolling", true);
            }
        }

        if (dashing)
        {
            dashTimer += Time.deltaTime;
            if(dashTimer > dashTime)
            {
                speed -= dashSpeed;
                dashing = false;
                playerAnimator.SetBool("isRolling", false);
            }
        }
    }
}

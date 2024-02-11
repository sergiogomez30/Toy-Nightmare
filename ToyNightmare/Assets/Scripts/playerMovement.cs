using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int speed;
    public int dashSpeed;
    public float dashTime;
    private bool dashing;
    private bool isMoving;

    float horizontal;
    float vertical;
    public Vector3 movementDirection;

    private void Start()
    {
        dashing = false;
    }

    private void Update()
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
        
        movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        isMoving = movementDirection != new Vector3(0, 0, 0);


        if (Input.GetMouseButtonDown(1))
        {
            if (!dashing && isMoving)
            {
                StartCoroutine(dash());
            }

        }


        //Mueve al jugador
        movementDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        print(movementDirection);
    }

    public IEnumerator dash()
    {
        speed = speed + dashSpeed;
        dashing = true;
        yield return new WaitForSeconds(dashTime);
        speed = speed - dashSpeed;
        dashing = false;
    }
}

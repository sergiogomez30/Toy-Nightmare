using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int speed = 3;
    float horizontal;
    float vertical;
    public Vector3 movementDirection;

    private void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal"); //GetAxisRaw permite ahorrarme el código comentado de abajo (antes utilizaba GetAxis)
        vertical = Input.GetAxisRaw("Vertical");

        /*//Asegura que el valor del axis horizontal sea 0 instantaneamente al soltar la tecla
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
        {
            horizontal = 0;
        }

        //Asegura que el valor del axis vertical sea 0 instantaneamente al soltar la tecla
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            vertical = 0;
        }

        //Asegura que el valor del axis horizontal sea 1 o -1 y no un número decimal cuando se mueve.
        //También para al jugador si se pulsan las dos teclas del mismo axis a la vez
        if (horizontal != 0) 
        {
            if (horizontal > 0)
            {
                horizontal = 1; 

                if (Input.GetKey(KeyCode.A)){ 
                    horizontal = 0;
                }
            }
            else if(horizontal < 0)
            {
                horizontal = -1;

                if (Input.GetKey(KeyCode.D))
                {
                    horizontal = 0;
                }
            }

        }

        //Asegura que el valor del axis vertical sea 1 o -1, y no un número decimal, cuando se mueve.
        //También para al jugador si se pulsan las dos teclas del mismo axis a la vez
        if (vertical != 0) 
        {
            if(vertical > 0) 
            {
                vertical = 1;

                if (Input.GetKey(KeyCode.S))
                {
                    vertical = 0;
                }
            }
            else if(vertical < 0)
            {
                vertical = -1;

                if (Input.GetKey(KeyCode.W))
                {
                    vertical = 0;
                }
            }
        }*/

        //Mueve al jugador
        movementDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        print(movementDirection);
    }
}

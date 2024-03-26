using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        Destroy(gameObject, 20);

        transform.position += transform.right * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Crosshair" && other.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }
    }
}

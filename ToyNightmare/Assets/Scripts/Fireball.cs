using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Destroy(gameObject, 20);

        transform.position += transform.up * speed * Time.deltaTime;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }
    }*/
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0)
        {
            Destroy(gameObject);
        }

    }
}

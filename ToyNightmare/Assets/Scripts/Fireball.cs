using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject bulletHitPrefab;
    

    void FixedUpdate()
    {
        Destroy(gameObject, 20);

        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8)
        {
            Instantiate(bulletHitPrefab, collision.contacts[0].point + new Vector3(0,0,-0.1f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private Animator bulletHitAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bulletHitAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletHitAnimator.GetCurrentAnimatorStateInfo(0).IsName("Delete"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPosition : MonoBehaviour
{
    Vector3 rightPosition;
    Vector3 leftPosition;

    void Start()
    {
        rightPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        leftPosition = new Vector3(transform.localPosition.x, -transform.localPosition.y, transform.localPosition.z);
    }

    public void fixPosition(Vector3 direction)
    {
        if (direction.x <= 0)
        {
            transform.localPosition = leftPosition;
        }
        else
        {
            transform.localPosition = rightPosition;
        }
    }
}

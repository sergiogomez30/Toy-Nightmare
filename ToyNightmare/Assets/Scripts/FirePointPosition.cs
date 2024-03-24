using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPosition : MonoBehaviour
{
    Vector3 initialFirePointPosition;
    Vector3 negativeInitialFirePointPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialFirePointPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        negativeInitialFirePointPosition = new Vector3(transform.localPosition.x, -transform.localPosition.y, transform.localPosition.z);
    }

    public void fixFirePointPosition(Vector3 direction)
    {
        if (direction.x <= 0)
        {
            transform.localPosition = negativeInitialFirePointPosition;
        }
        else
        {
            transform.localPosition = initialFirePointPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    public Camera cam;
    [SerializeField] private LayerMask floorMask;
    private Vector3 mouseWorldPoint;

    public Sprite crosshairSprite;
    public Sprite noneSprite;

    private SpriteRenderer crosshairRenderer;

    private void Start()
    {
        Cursor.visible = false;

        crosshairRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, floorMask))
        {
            mouseWorldPoint = raycastHit.point;
        }

        //print(Input.mousePosition);

        transform.position = mouseWorldPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Walls")
        {
            crosshairRenderer.sprite = noneSprite;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        crosshairRenderer.sprite = crosshairSprite;
    }
}



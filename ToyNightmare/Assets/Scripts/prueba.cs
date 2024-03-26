using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    // Reference to the RectTransform component of the crosshair UI
    private RectTransform crosshairRectTransform;

    void Start()
    {
        Cursor.visible = false;
        // Get reference to the RectTransform component
        crosshairRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Convert mouse position to Canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(crosshairRectTransform.parent as RectTransform, Input.mousePosition, null, out Vector2 localPoint);

        // Set crosshair position
        crosshairRectTransform.localPosition = localPoint;
    }
}

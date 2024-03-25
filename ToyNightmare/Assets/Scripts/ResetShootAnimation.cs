using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetShootAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spriteNone;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void resetSprite()
    {
       spriteRenderer.sprite = spriteNone;
    }
}

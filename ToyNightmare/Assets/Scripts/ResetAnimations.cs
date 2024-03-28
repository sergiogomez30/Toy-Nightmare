using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite spriteNone;
    public Sprite weapon;
    private SpriteRenderer shootEffectRenderer;
    private SpriteRenderer weaponRenderer;

    private void Start()
    {
        shootEffectRenderer = GameObject.Find("ShootEffect").GetComponent<SpriteRenderer>();
        weaponRenderer = GameObject.Find("Weapon").GetComponent<SpriteRenderer>();
    }

    public void resetShootEffectSprite()
    {
       shootEffectRenderer.sprite = spriteNone;
    }

    public void resetWeaponSprite()
    {
        weaponRenderer.sprite = weapon;
    }
}

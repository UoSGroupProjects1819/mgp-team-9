using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the following components will be added when adding a shield script onto a gameobject
[RequireComponent(typeof(BoxCollider2D))]
public class shieldScript : MonoBehaviour
{
    // VV finish the shield co-routine
    private BoxCollider2D shieldHitBox;

    /*public float cooldownTime;
    private float timeSinceLastShield;
    public float shieldCharge;*/

    // Start is called before the first frame update
    void Start()
    {
        shieldHitBox = GetComponent<BoxCollider2D>();
        shieldEnabled(true);
    }

    private void shieldEnabled(bool enableState)
    {
        // show the shield and activate it's hitbox so it can collide
        shieldHitBox.enabled = enableState;
    }
}

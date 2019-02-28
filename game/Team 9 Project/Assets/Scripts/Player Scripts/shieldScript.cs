using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the following components will be added when adding a shield script onto a gameobject
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class shieldScript : MonoBehaviour
{
    // VV finish the shield co-routine
    private SpriteRenderer shieldRenderer;
    private CircleCollider2D shieldHitBox;

    public float shieldStayTime;
    private bool canDeployShield = true;
    public float coolDownTime;

    /*public float cooldownTime;
    private float timeSinceLastShield;
    public float shieldCharge;*/

    // Start is called before the first frame update
    void Start()
    {
        shieldRenderer = GetComponent<SpriteRenderer>();
        shieldHitBox = GetComponent<CircleCollider2D>();
        shieldEnabled(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Shield") > 0 && canDeployShield)
        {
            StartCoroutine(deployShield());
            StartCoroutine(shieldCooldown());
        }
    }

    private IEnumerator deployShield()
    {
        // enable the shield for the time it is supposed to be there
        shieldEnabled(true);
        yield return new WaitForSeconds(shieldStayTime);
        shieldEnabled(false);
    }

    private IEnumerator shieldCooldown()
    {
        canDeployShield = false;
        yield return new WaitForSeconds(coolDownTime);
        canDeployShield = true;
    }

    private void shieldEnabled(bool enableState)
    {
        // show the shield and activate it's hitbox so it can collide
        shieldRenderer.enabled = enableState;
        shieldHitBox.enabled = enableState;
    }
}

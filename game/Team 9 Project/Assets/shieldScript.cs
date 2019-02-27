using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    //[RequireComponent(SpriteRenderer)] <- fix that
    // VV finish the shield co-routine
    public SpriteRenderer shieldRenderer;

    public float shieldStayTime;
    private bool shieldDeployed;
    /*public float cooldownTime;
    private float timeSinceLastShield;
    public float shieldCharge;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Shield") > 0 && !shieldDeployed)
        {
            StartCoroutine(deployShield());
        }
    }

    private IEnumerator deployShield()
    {
        shieldDeployed = true;
        yield return new WaitForSeconds(shieldStayTime);
        shieldDeployed = false;
    }
}

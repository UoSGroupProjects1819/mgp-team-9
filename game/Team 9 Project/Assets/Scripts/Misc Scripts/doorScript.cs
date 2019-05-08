using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(shieldScript))]
public class doorScript : MonoBehaviour
{
    private bool open;
    private enemySpawnControl EnemySpawnControl;
    private BoxCollider2D boxCollider;

    private bool roomEntered = false;
    private Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnControl = transform.parent.GetComponentInChildren<enemySpawnControl>();
        boxCollider = GetComponent<BoxCollider2D>();
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            //this.gameObject.SetActive(false);
            boxCollider.enabled = false;
            // change the sprite
            doorAnim.SetBool("DoorOpen", true);
        }
        else
        {
            StartCoroutine(checkIfWavesEnded());
        }
    }

    private IEnumerator checkIfWavesEnded()
    {
        roomEntered = EnemySpawnControl.roomEntered;
        yield return new WaitForSeconds(0.5f);
        if(EnemySpawnControl.enemyCount == 0 && roomEntered)
        {
            Debug.Log("Stage Finished!" + transform.parent.name);
            open = true;
        }
    }
}
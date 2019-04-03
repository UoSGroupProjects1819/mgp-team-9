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
    private SpriteRenderer spriteRenderer;

    private bool roomEntered = false;

    public Sprite doorOpenSprite;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnControl = transform.parent.GetComponentInChildren<enemySpawnControl>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            boxCollider.enabled = false;
            // change the sprite
            //spriteRenderer.sprite = doorOpenSprite;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1.5f, 1.5f, 1.5f));
    }
}
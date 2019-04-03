using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    private GameObject player;

    [Header("Collision Detection")]
    public LayerMask enemyLayerMask;
    public LayerMask playerLayerMask;
    public Rigidbody2D enemyRigidbody;
    [Header("Enemy Movement")]
    public float enemyMoveSpeed;
    [Range(0, 0.1f)]
    public float enemyStrafeSpeed;
    public float shootStandTime;

    [Header("Enemy Health")]
    public float enemyMaxHealth;
    public float enemyCurrentHealth;

    [HideInInspector]
    public Vector2 vectorToPlayer;
    [Header("Enemy Engagement")]
    public float fleeRadius;
    public float stayRadius;

    [Header("Enemy Misc Items")]
    public shootScript enemyShoot;
    private Vector2 aimVector;
    public GameObject shootLocation;
    RaycastHit2D[] hit;

    [Header("Enemy Animation")]
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D[] hit = Physics2D.RaycastAll(shootLocation.transform.position, vectorToPlayer, Mathf.Infinity, enemyLayerMask.value);
        RaycastHit2D[] hit2 = Physics2D.RaycastAll(shootLocation.transform.position, vectorToPlayer, Mathf.Infinity, playerLayerMask.value);
        Debug.DrawRay(shootLocation.transform.position, vectorToPlayer, Color.yellow, 0.5f);

        if (hit.Length >= 1)
        {
            enemyShoot.canShoot = true;
        }
        else
        {
            enemyShoot.canShoot = false;
        }

        // possibly move this VV when there is an "aggro" (if it exists)
        vectorToPlayer = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        // move the enemy towards the player
        if (vectorToPlayer.magnitude > stayRadius)
        {
            EnemyMove();
        }
        else if(vectorToPlayer.magnitude < fleeRadius){
            EnemyMoveAway();
        }
        else
        {
            // move in a cirle when not moving towards or away from the player
            if (enemyShoot.shooting)
            {
                enemyRigidbody.velocity = Vector2.zero;
                StartCoroutine(shootWait());
            }
            else
            {
                transform.Translate(new Vector3(enemyStrafeSpeed, 0f, 0f));
            }
        }
        // aim AT the player
        EnemyAim();

        if(enemyCurrentHealth <= 0)
        {
            Debug.Log("enemy dead");
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator shootWait()
    {
        enemyAnimator.SetTrigger("Shoot");
        yield return new WaitForSeconds(shootStandTime);
        enemyShoot.shooting = false;
    }

    private void EnemyMoveAway()
    {
        enemyRigidbody.velocity = vectorToPlayer.normalized * enemyMoveSpeed * -1;
    }

    private void EnemyMove()
    {
        // go to player
        enemyRigidbody.velocity = vectorToPlayer.normalized * enemyMoveSpeed;
        // hover around a radius of the player
        // circle the player?
    }

    private void EnemyAim()
    {
        transform.up = player.transform.position - transform.position;
        Vector2 aimVector = vectorToPlayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // take health away from the player
            enemyCurrentHealth -= collision.gameObject.GetComponent<bulletScript>().bulletDamage;
            StartCoroutine(playHitAnimation());
        }
    }

    public IEnumerator playHitAnimation()
    {
        enemyAnimator.SetTrigger("Hit");
        yield return new WaitForSeconds(1f);
        transform.parent.GetComponentInChildren<enemySpawnControl>().enemyCount -= 1;
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        // draw fleeRadius in scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);
        // draw stayRadius in scene
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stayRadius);
        // draw the raycast
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(shootLocation.transform.position, aimVector);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBasic : MonoBehaviour
{
    private GameObject player;

    public Rigidbody2D enemyRigidbody;
    public float enemyMoveSpeed;

    public Vector2 vectorToPlayer;
    private bool chasingPlayer = true;

    public float fleeRadius;
    public float stayRadius;

    public float shootStandTime;
    public shootScript enemyShoot;
    private Vector2 aimVector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // possibly move this VV when there is an "aggro" (if it exists)
        vectorToPlayer = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        // move the enemy towards the player
        if (chasingPlayer && vectorToPlayer.magnitude > stayRadius)
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
                transform.Translate(new Vector3(0.1f, 0f, 0f));
            }
        }
        // aim AT the player
        EnemyAim();
        // shoot bullet (co-routine so we can easily add a shoot period)
    }

    private IEnumerator shootWait()
    {
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
        //transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x - this.transform.position.x, 0f, player.transform.position.y - this.transform.position.y));
        Vector2 aimVector = vectorToPlayer;
    }

    private void OnDrawGizmos()
    {
        // draw fleeRadius in scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);
        // draw stayRadius in scene
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stayRadius);
    }
}
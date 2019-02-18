using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bullet is moving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
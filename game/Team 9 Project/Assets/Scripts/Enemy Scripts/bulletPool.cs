using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    private List<GameObject> bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> buildBulletPool()
    {
        foreach (Transform child in gameObject.transform)
        {
            bullets.Add(child.gameObject);
        }

        return bullets;
    }
}

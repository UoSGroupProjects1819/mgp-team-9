using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - offset);
        this.transform.position = cameraPos;
    }
}

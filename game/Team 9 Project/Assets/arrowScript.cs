using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    // arrow needs to point at the next door
    public GameObject[] rooms;
    private int room = -1;

    private GameObject currentDoor;
    private GameObject currentSpawner;

    private void Start()
    {
        NextDoor();
    }
    private void Update()
    {
        transform.up = currentDoor.transform.position - transform.position;
    }
    // point to room 0 door
    // when room i spawner enemycount == 0,
    //    point to next door

    private void NextDoor()
    {
        room += 1;
        currentSpawner = rooms[room].gameObject.transform.GetChild(0).gameObject;
        currentDoor = rooms[room].gameObject.transform.GetChild(1).gameObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPointGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 1f);
    }
}

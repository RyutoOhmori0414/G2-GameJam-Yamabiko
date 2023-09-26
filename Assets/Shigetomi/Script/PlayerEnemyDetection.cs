using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SpwanPoint")
        {
            GetComponent<EnemySpawn>().Spawn();
        }
    }
}

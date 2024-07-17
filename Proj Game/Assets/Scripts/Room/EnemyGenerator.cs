using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private Room iRoom;

    private void Awake()
    {
        iRoom = transform.parent.GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transform.parent.GetComponentInParent<BasicRoomBehaviour>().EnemyGenerated())
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Enter Room");
                iRoom.entityLayerl.GetComponent<EntityLayerBeh>().GenerateEnemy();
                transform.parent.GetComponentInParent<BasicRoomBehaviour>().EnemyGenerateSet();
            }
        }
            
    }
}

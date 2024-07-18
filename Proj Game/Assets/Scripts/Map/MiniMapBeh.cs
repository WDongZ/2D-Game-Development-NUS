using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapBeh : MonoBehaviour
{
    GameObject MiniRoomMap;
    // Start is called before the first frame update
    void Start()
    {
        MiniRoomMap = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
            MiniRoomMap.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
            MiniRoomMap.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            MiniRoomMap.GetComponent<SpriteRenderer>().enabled = false;
    }

}

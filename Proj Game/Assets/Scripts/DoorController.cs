using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            GetComponentInParent<Room>().transform.Find("Mask").gameObject.SetActive(false);
            GameObject.Find("Camera").transform.position = transform.position;
            transform.parent.transform.parent.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<SpriteRenderer>().enabled = false;
    }

}

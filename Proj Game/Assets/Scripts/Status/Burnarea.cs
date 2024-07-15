using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnarea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<BurnStatus>().GetStatus(other.gameObject);
        }
        if(other.tag == "Enemy")
        {
            GetComponent<BurnStatus>().GetStatus(other.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<BurnStatus>().GetStatus(other.gameObject);
        }
        if(other.tag == "Enemy")
        {
            GetComponent<BurnStatus>().GetStatus(other.gameObject);
        }
    }

}

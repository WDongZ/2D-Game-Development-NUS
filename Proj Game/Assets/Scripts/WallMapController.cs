using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMapController : MonoBehaviour
{
    private SpriteRenderer render;

    void Awake()
    {
        render = transform.parent.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        render.enabled = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") render.enabled = true;
    }

}

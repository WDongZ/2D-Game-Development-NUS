using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMapController : MonoBehaviour
{
    private SpriteRenderer render;
    private SpriteRenderer[] renders;

    void Awake()
    {
        render = transform.parent.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        renders = transform.parent.GetChild(0).GetComponentsInChildren<SpriteRenderer>();
        render.enabled = false;
        foreach (var rend in renders)
        {
            rend.enabled = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            render.enabled = true;
            foreach (var rend in renders)
            {
                rend.enabled = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            render.enabled = true;
            foreach (var rend in renders)
            {
                rend.enabled = true;
            }
        }
    }

}

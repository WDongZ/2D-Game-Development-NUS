using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointBehaviour : MonoBehaviour
{
    private Vector3 iniPos;
    private float delta;
    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.position;
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        delta = c.a * 0.25f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;

        c.r -= delta;
        c.a -= delta;
        s.color = c;
        Debug.Log("WayPoint: Color = " + c);

        if (c.a <= 0.0f)
        {
            RandomGenerate();
        }
    }
    private void RandomGenerate()
    {
        float deltaX = Random.Range(-15f, 15f);
        float deltaY = Random.Range(-15f, 15f);
        transform.localPosition = new Vector3(iniPos.x + deltaX, iniPos.y + deltaY, iniPos.z);
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;
        c.r += delta * 4;
        c.a += delta * 4;
        s.color = c;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Egg(Clone)")
            UpdateColor();
    }
}

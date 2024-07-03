using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    static private GreenArrowBehavior sGreenArrow = null;
    static public void SetGreenArrow(GreenArrowBehavior g) { sGreenArrow = g; }

    private const float kEggSpeed = 40f;
    private Vector3 mRotation;
    private Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        mRotation = sGreenArrow.transform.eulerAngles;
        mRotation.y = 0f;
        transform.eulerAngles = mRotation;
        endPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (kEggSpeed * Time.smoothDeltaTime);
        
        if (Mathf.Abs(transform.position.x) > endPos.x || Mathf.Abs(transform.position.y) > endPos.y)
        {
            destroyEgg();
        }

    }

    private void destroyEgg()
    {
        Destroy(transform.gameObject);
        sGreenArrow.OneLessEgg();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Plane(Clone)" || collision.gameObject.name.Contains("WayPoint"))
            destroyEgg();
    }
}

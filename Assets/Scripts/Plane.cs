using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Plane: MonoBehaviour
{
    static private GameManager sGameManager = null;
    private GameObject mMyTarget = null;
    private const float kMySpeed = 20f;
    private int currentTarget = 1;
    private float mTurnRate = 0.03f;
    private const float kVeryClose = 25f;

    static public void SetGameManager(GameManager gm) { sGameManager = gm;}

    private float delta;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        mMyTarget = sGameManager.GetTarget(currentTarget);
        Color c = s.color;
        delta = c.a * 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTargetPosition();
        PointAtPosition(mMyTarget.transform.localPosition, mTurnRate * Time.smoothDeltaTime);
        transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;
    }

    private void UpdateColor()
    {
        SpriteRenderer s = GetComponent<SpriteRenderer>();
        Color c = s.color;

        c.r -= delta;
        c.a -= delta;
        s.color = c;
        Debug.Log("Plane: Color = " + c);

        if (c.a <= 0.0f)
        {
            sGameManager.OneMoreDestroy();
            destroyPlane();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Egg(Clone)")
            UpdateColor();
        if (collision.gameObject.name == "GreenUp")
        {
            sGameManager.OneMoreDestroy();
            sGameManager.OneMoreTouch();
            destroyPlane();
        }
    }

    private void destroyPlane()
    {
        Destroy(transform.gameObject);
        sGameManager.OneLessPlane();
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    private void CheckTargetPosition()
    {
        // Access the GameManager
        float dist = Vector3.Distance(mMyTarget.transform.localPosition, transform.localPosition);
        if (dist < kVeryClose)
        {
            currentTarget = currentTarget + 1 == 7 ? 1 : currentTarget + 1;
            mMyTarget = sGameManager.GetTarget(currentTarget);
        }
    }
}

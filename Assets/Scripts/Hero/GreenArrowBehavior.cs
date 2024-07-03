using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowBehavior : MonoBehaviour
{
    private int mTotalEggCount = 0;
    private float mCoolDownTime = .2f;
    public CoolDownBar mCoolDown;
    private float mEggSpawnAt = 0f;
    public bool mFollowMousePosition = true;
    public float mHeroSpeed = 20f;
    [SerializeField]
    private float mHeroRotateSpeed = 90f / 2f; // 90-degrees in 2 seconds
    [SerializeField]
    private float mAcceleration = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mCoolDown != null);    // Must be set in the editor
        mEggSpawnAt = Time.time;  // time since the beginning of frame
        mCoolDown.SetCoolDownLength(mCoolDownTime);
    }

    void Update()
    {

        Vector3 p = transform.localPosition;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(transform.forward, mHeroRotateSpeed * Time.smoothDeltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(transform.forward, -mHeroRotateSpeed * Time.smoothDeltaTime);

        if (Input.GetKeyDown(KeyCode.M))
        {
            mFollowMousePosition = !mFollowMousePosition;
            Debug.Log("Current control mode Mouse=" + mFollowMousePosition);
        }

        if (mFollowMousePosition)
        {
            p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f; 
        }
        else
        {
            p += ((mHeroSpeed * Time.smoothDeltaTime) * transform.up);

            if (Input.GetKey(KeyCode.W))
                mHeroSpeed += Time.smoothDeltaTime * mAcceleration;

            if (Input.GetKey(KeyCode.S))
                mHeroSpeed -= Time.smoothDeltaTime * mAcceleration;
        }

        transform.localPosition = p;
        if (Input.GetKey(KeyCode.Space))
        {
            if (mCoolDown.ReadyForNext())
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject); // Prefab MUST BE locaed in Resources/Prefab folder!
                e.transform.localPosition = transform.localPosition;
                // Debug.Log("Spawn Eggs:" + e.transform.localPosition);
                mTotalEggCount++;

                mCoolDown.TriggerCoolDown();
            }
        }

    }
    
    public void OneLessEgg() { mTotalEggCount--;  }

    public string EggStatus() { return "Eggs on screen: " + mTotalEggCount; }

    public string CtrlMode() { return "Control Mode: " + (mFollowMousePosition ? "Mouse" : "Keyboard"); }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required to work with UI
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sTheGlobalBehavior = null; // Single pattern

    public GreenArrowBehavior mHero = null;  // must set in the editor

    private int enemyNumber = 10;

    private int currentEnemy = 0;

    private int heroTouchCount = 0;

    private int destroyCount = 0;

    private bool isActive = true;

    private bool randomMode = false;

    private Vector2 endPos;
    // for display egg count
    public TMP_Text mEggCountEcho = null;

    public TMP_Text mCtrlModeEcho = null;

    public TMP_Text mHeroTouchEcho = null;

    public TMP_Text mDestroyEcho = null;

    public TMP_Text mEnemyEcho = null;

    public TMP_Text mRandomModeEcho = null;

    public WayPointBehaviour mWayPointA = null;
    public WayPointBehaviour mWayPointB = null;
    public WayPointBehaviour mWayPointC = null;
    public WayPointBehaviour mWayPointD = null;
    public WayPointBehaviour mWayPointE = null;
    public WayPointBehaviour mWayPointF = null;

    // Start is called before the first frame update
    void Start()
    {
        endPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        createPlane();
        GameManager.sTheGlobalBehavior = this;  // Singleton pattern
        Debug.Assert(mEggCountEcho != null);    // Assume setting in the editor!
        Debug.Assert(mHero != null);
        Debug.Assert(mCtrlModeEcho != null);
        Debug.Assert(mHeroTouchEcho != null);
        Debug.Assert(mDestroyEcho != null);
        Debug.Assert(mEnemyEcho != null);
        Debug.Assert(mRandomModeEcho != null);
        Debug.Assert(mWayPointA != null);
        Debug.Assert(mWayPointB != null);
        Debug.Assert(mWayPointC != null);
        Debug.Assert(mWayPointD != null);
        Debug.Assert(mWayPointE != null);
        Debug.Assert(mWayPointF != null);

        // Connect up everyone who needs to know about each other
        EggBehavior.SetGreenArrow(mHero);
        Plane.SetGameManager(this);
        // Notice the symantics: this is a call to class method (NOT instance method)
    }


    // Update is called once per frame
    void Update()
    {
        mEggCountEcho.text = mHero.EggStatus();
        mCtrlModeEcho.text = mHero.CtrlMode();
        mHeroTouchEcho.text = "Hero Touch Count: " + heroTouchCount;
        mDestroyEcho.text = "Total Destroy Count: " + destroyCount;
        mEnemyEcho.text = "Total Enemy Count: " + currentEnemy;
        mRandomModeEcho.text = randomMode ? "WayPoints: (Random)" : "WayPoints: (Sequence)";
        if (currentEnemy < enemyNumber)
            createPlane();
        if (Input.GetKeyDown(KeyCode.H))
        {
            isActive = !isActive;
            mWayPointA.GetComponent<SpriteRenderer>().enabled = isActive;
            mWayPointB.GetComponent<SpriteRenderer>().enabled = isActive;
            mWayPointC.GetComponent<SpriteRenderer>().enabled = isActive;
            mWayPointD.GetComponent<SpriteRenderer>().enabled = isActive;
            mWayPointE.GetComponent<SpriteRenderer>().enabled = isActive;
            mWayPointF.GetComponent<SpriteRenderer>().enabled = isActive;
        }
        if (Input.GetKeyDown(KeyCode.J)) { randomMode = !randomMode; }
    }

    private void createPlane()
    {
        while (currentEnemy < enemyNumber)
        {
            GameObject e = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);
            Vector3 randPos = new Vector3();
            randPos.x = Random.Range(-endPos.x * 0.9f, endPos.x * 0.9f);
            randPos.y = Random.Range(-endPos.y * 0.9f, endPos.y * 0.9f);
            randPos.z = 0;
            e.transform.localPosition = randPos;
            currentEnemy++;
        }
    }

    public void OneLessPlane() { currentEnemy--; }

    public void OneMoreTouch() { heroTouchCount++; }

    public void OneMoreDestroy() { destroyCount++; }

    public GameObject GetTarget(int currentTarget)
    {
        int mTarget = randomMode ? Random.Range(1, 7) : currentTarget;
        switch (mTarget)
        {
            case 1: return GameObject.Find("WayPointA");
            case 2: return GameObject.Find("WayPointB");
            case 3: return GameObject.Find("WayPointC");
            case 4: return GameObject.Find("WayPointD");
            case 5: return GameObject.Find("WayPointE");
            case 6: return GameObject.Find("WayPointF");
        }
        return null;
    }
}

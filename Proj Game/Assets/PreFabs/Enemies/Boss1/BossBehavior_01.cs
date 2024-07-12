using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior_01 : MonoBehaviour
{
    public GameObject laser;
    public float laserRotateSpeed = 10f;
    private Animator anim;
    private bool laserCasting;
    [SerializeField] private float timmer = 0;
    private GameObject iLaser;
    private int currentState = 0;
    [SerializeField] private float timeC = 0;
    [SerializeField] private float timeR = 0;
    [SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 100;
    [SerializeField] private float hateDis = 10;
    private GameObject player;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        StateMachine(currentState);
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:
                if (Vector2.Distance(player.transform.position,transform.position) > hateDis) { currentState = 3; }
                else if (timmer > 3 || timeChasing > 1)
                {
                    currentState = 1;
                    timmer = 0;
                    timeChasing = 0;
                } else
                {
                    timmer += Time.deltaTime;
                }
                break;
            case 1:
                LaserCasting();
                timeC = 0;
                timeR = Random.Range(2f, 4f);
                currentState = 2;
                break;
            case 2:
                LaserRotate();
                break;
            case 3:
                timeChasing += Time.deltaTime;
                MoveTowardPlayer(GameObject.Find("Player").transform.localPosition);
                if (Vector2.Distance(player.transform.position, transform.position) < hateDis) {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    currentState = 0; 
                }
                break;

        }
    }

    private void LaserRotate()
    {
        timeC += Time.deltaTime;
        if (timeC > timeR) laserCasting = false;
        anim.SetBool("laserCasting", laserCasting);
        if (laserCasting)
        {
            iLaser.transform.eulerAngles = new Vector3(iLaser.transform.eulerAngles.x,
        iLaser.transform.eulerAngles.y, iLaser.transform.eulerAngles.z + laserRotateSpeed * Time.deltaTime);
        }
        if (!laserCasting)
        {
            iLaser.GetComponent<LaserController>().StopLaser();
            currentState = 0;
        }
    }


    private void MoveTowardPlayer(Vector3 p)
    {
        Vector2 tSpeed = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(tSpeed.x * moveSpeed * 100, tSpeed.y * moveSpeed * 100); 
    }

    [System.Obsolete]
    private void LaserCasting()
    {
        laserCasting = true;
        iLaser = Instantiate(laser, transform.GetChild(1).position, Quaternion.EulerAngles(0, 0, Random.Range(-180f, 180f)));
    }

    private void OnDestroy()
    {
        iLaser.GetComponent<LaserController>().StopLaser();
        GameObject.Find("Canvas").GetComponent<UIController>().GameWin();
    }

}

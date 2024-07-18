
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior_01 : MonoBehaviour
{
    private float chasingDuration = 2f;
    public GameObject laser;
    public GameObject APs;
    public float laserRotateSpeed = 3f;
    private Animator anim;
    private bool laserCasting;
    private bool APCasting;
    private int APCount = 0;
    private bool isImmune;
    [SerializeField] private int immuneCount = 1;
    [SerializeField] private float timmer = 0;
    private GameObject iLaser;
    [SerializeField] private int currentState = 0;
    [SerializeField] private float timeC = 0;
    [SerializeField] private float timeR = 0;
    [SerializeField] private float timeI = 0;
    [SerializeField] private float timeChasing = 0;
    [SerializeField] private float moveSpeed = 100;
    [SerializeField] private float hateDis = 10;
    [SerializeField] private float healthUpRate = 0.5f;
    private GameObject player;
    private float HP_Upbound;
    public GameObject pipo;
    public GameObject lighten;
    private Animator pipoAnim;
    private Animator lightAnim;
    private GameObject winMenu;
    void Start()
    {
        winMenu = GameObject.Find("Canvas/winMenu");
        HP_Upbound = GetComponent<EnemyController>().HP;
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        pipoAnim = pipo.GetComponent<Animator>();
        lightAnim = lighten.GetComponent<Animator>();
    }

    void Update()
    {
        moveSpeed = GetComponent<EntityAttribute>().moveSpeed;
        if (GetComponent<EnemyController>().HP <= 0) {
            SceneManager.LoadScene("Ending");
            transform.GetChild(0).gameObject.SetActive(false);
            iLaser.GetComponent<LaserController>().StopLaser();
            Debug.Log(GameObject.Find("Canvas").GetComponent<UIController>());
        }
        StateMachine(currentState);
        anim.SetBool("laserCasting", laserCasting);
        anim.SetBool("isImmune", isImmune);
        anim.SetBool("APCasting", APCasting);
        pipoAnim.SetBool("Pipo_On", isImmune);
        if (GetComponent<EnemyController>().HP <= HP_Upbound * 0.5 && immuneCount == 1) {
            currentState = 4;
            chasingDuration = 1f;
            iLaser.GetComponent<LaserController>().StopLaser();
            laserCasting = false;
        }
    }

    private void StateMachine(int state)
    {
        switch (state)
        {
            case 0:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (Vector2.Distance(player.transform.position,transform.position) > hateDis && timeChasing < chasingDuration) {
                    timeChasing = 0;
                    currentState = 3; 
                }
                else if (timmer > chasingDuration || timeChasing > chasingDuration)
                {
                    if (GetComponent<EnemyController>().HP > HP_Upbound * 0.5) currentState = 1;
                    else {
                        float randomState = Random.value;
                        if (randomState < 0.3) currentState = 1;
                        else if (randomState >= 0.3 && randomState < 0.85) currentState = 6;
                        else currentState = 4;
                    }
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
                timeR = Random.Range(4f, 8f);
                currentState = 2;
                break;
            case 2:
                LaserRotate();
                break;
            case 3:
                timeChasing += Time.deltaTime;
                MoveTowardPlayer(GameObject.Find("Player").transform.localPosition);
                if (Vector2.Distance(player.transform.position, transform.position) < hateDis || timeChasing > chasingDuration) {
                    currentState = 0; 
                }
                break;
            case 4:
                timeI = 0;
                APsCasting();
                GetImmune();
                currentState = 5;
                break;
            case 5:
                timeI += Time.deltaTime;
                if (APCount == 0)
                {
                    LossImmune();
                }
                if (timeI > 5 && GetComponent<EnemyController>().HP < HP_Upbound)
                {
                    GetComponent<EnemyController>().HP += healthUpRate * Time.deltaTime;
                }
                if (GetComponent<EnemyController>().HP > HP_Upbound * 0.6)
                {
                    immuneCount = 1;
                    chasingDuration = 3f;
                }
                break;
            case 6:
                Lightening();
                currentState = 0;
                break;
        }
    }

    private void Lightening()
    {
        lighten.GetComponent<Lighten>().StartLighten();
    }


    private void LaserRotate()
    {
        timeC += Time.deltaTime;
        if (timeC > timeR) laserCasting = false;
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

    private void APsCasting()
    {
        APCount += 5;
        APCasting = true;
        Instantiate(APs, transform.GetChild(1).position, Quaternion.identity);
    }

    private void GetImmune()
    {
        immuneCount--;
        isImmune = true;
        GetComponent<EnemyController>().hurtFactor = 0;
    }

    private void LossImmune()
    {
        isImmune = false;
        GetComponent<EnemyController>().hurtFactor = 1;
    }

    public void CurrentStateToZero()
    {
        currentState = 0;
    }

    public void LossAP()
    {
        APCount--;
    }

    private void OnDestroy()
    {
        //winMenu.SetActive(true);
        //GameObject.Find("Canvas").GetComponent<UIController>().GameWin();
        //SceneManager.LoadScene("Ending");
        iLaser.GetComponent<LaserController>().StopLaser();
    }

}

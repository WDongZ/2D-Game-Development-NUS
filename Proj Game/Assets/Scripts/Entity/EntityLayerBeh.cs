using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityLayerBeh : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    [SerializeField] private GameObject Faz;

    private float timer = 0;

    private bool isGenearting = false;

    void Awake()
    {
        foreach(Transform gobj in transform)
        {
            if (gobj.CompareTag("Enemy"))
            {
                enemies.Add(gobj.gameObject);
                gobj.gameObject.SetActive(false);
            }
            
        }
        
    }

    private void Update()
    {
        timer += Time.smoothDeltaTime;
        if (timer > 1.2f && isGenearting) EnemyActive();
    }


    public void GenerateEnemy()
    {
        Debug.Log("Enemy Generate!!!");
        isGenearting = true;
        timer = 0;
        foreach (GameObject e in enemies)
        {
            GameObject iFaz = Instantiate(Faz,e.transform.position,Faz.transform.rotation);
        }
    }

    private void EnemyActive()
    {
        foreach(GameObject e in enemies)
        {
            e.SetActive(true);
        }
        isGenearting = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public List<GameObject> propList;

    public List<float> rateList;

    private EntityAttribute enemy;
    void Awake()
    {

        enemy = GetComponent<EntityAttribute>();
    }

    void OnDestroy()
    {
        if(enemy.HP <= 0)
        {
            float randomRate = Random.value;
            float rate = 0;
            GameObject drop = null;
            for (int i = 0; i < propList.Count; i++)
            {
                rate += rateList[i];
                if (randomRate < rate) {
                    drop = propList[i];
                    break;
                }
            }
            Instantiate(drop, enemy.transform.position, drop.transform.rotation);
        }
    }
}

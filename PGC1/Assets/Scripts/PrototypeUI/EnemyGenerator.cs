using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float xLoc;
    public float yLoc;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GenerateEnemy()
    {
        xLoc += Random.Range(-0.5f, 0.5f);
        yLoc += Random.Range(-0.5f, 0.5f);
        GameObject mEnemy = Instantiate(enemy, new Vector3(xLoc,yLoc,0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    void Start()
    {
        SceneManager.MoveGameObjectToScene(GameObject.Find("Player"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(Camera.main.gameObject , SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("Camera"), SceneManager.GetActiveScene());
        SceneManager.MoveGameObjectToScene(GameObject.Find("Virtual Camera"), SceneManager.GetActiveScene());
    }

}

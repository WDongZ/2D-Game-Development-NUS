using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void RoomGeneratorScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

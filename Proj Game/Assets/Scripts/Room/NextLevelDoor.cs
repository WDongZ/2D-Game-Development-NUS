using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{

    private bool InRange = false;

    public GameObject FButton;

    void Start()
    {
        foreach (Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.F))
        {
            GetInNext();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
            FButton.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
            FButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            FButton.SetActive(false);
        }
    }

    private void GetInNext()
    {
        DontDestroyOnLoad(GameObject.Find("Player"));
        DontDestroyOnLoad(Camera.main.gameObject);
        DontDestroyOnLoad(GameObject.Find("Camera"));
        DontDestroyOnLoad(GameObject.Find("Virtual Camera"));
        SceneManager.LoadScene("MainScene2");
    }

}

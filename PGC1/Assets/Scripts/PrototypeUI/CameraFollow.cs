using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private SpriteRenderer render;
    private bool renderEnable = false;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ShowRender()
    {
        renderEnable = !renderEnable;
        render.enabled = renderEnable;
    }
}

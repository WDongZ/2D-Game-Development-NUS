using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOnAltar : MonoBehaviour
{
    public float Hz = 1.0f; //频率

    public float Am = 0.5f; //振幅

    private Vector3 Pos;

    void Start()
    {
        Pos = transform.position;
    }

    void Update()
    {
        Vector3 tempPos = Pos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Hz) * Am;
        transform.position = tempPos;
    }
}

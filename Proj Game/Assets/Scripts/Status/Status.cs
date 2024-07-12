using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    private GameObject iObject;
    private float lastingTime;
    private float timer = 0;
    private bool statusLasting = false;
    private void Awake()
    {
        GetStatus(iObject);
        statusLasting = true;
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (statusLasting && timer > lastingTime) Destroy(gameObject);
    }
    public Status (GameObject iObject, float lastingTime)
    {
        this.iObject = iObject;
        this.lastingTime = lastingTime;
    }
    public void GetStatus(GameObject iObject) { }

    public void LossStatus(GameObject iObject) { }

    private void OnDestroy()
    {
        LossStatus(iObject);
    }
}

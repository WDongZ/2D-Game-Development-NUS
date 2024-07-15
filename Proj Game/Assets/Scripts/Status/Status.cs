using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public GameObject iObject;
    public float lastingTime;
    public float timer = 0;
    public bool statusLasting = false;
    public GameObject statusEffect;

    public void setStatus(GameObject iObject)
    {
        this.iObject = iObject;
        GetStatus(iObject);
        statusLasting = true;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (statusLasting && timer > lastingTime)
        {
            Debug.Log("Loss sssssss");
            Destroy(gameObject);
        }
    }

    public abstract void GetStatus(GameObject iObject);

}

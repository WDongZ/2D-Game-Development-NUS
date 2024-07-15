using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttribute : MonoBehaviour
{
    public float HP;
    public float damage;
    public float hurtFactor = 1;
    public float moveSpeed;
    public List<Status> statusList = new List<Status>();

    public void GetStatus(Status status)
    {
        statusList.Add(status);
    }

    public void LossStatus(Status status)
    {
        statusList.Remove(status);
    }
}

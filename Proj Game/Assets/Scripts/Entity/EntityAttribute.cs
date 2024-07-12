using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttribute : MonoBehaviour
{
    public float HP;
    public float damage;
    public float moveSpeed;
    public List<Status> status = new List<Status>();

    public void GetStatus()
    {

    }
}

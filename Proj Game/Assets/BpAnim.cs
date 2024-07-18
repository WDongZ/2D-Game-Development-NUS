using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BpAnim : MonoBehaviour
{
    public void EndShake()
    {
        GetComponent<Animator>().SetBool("isShake", false);
    }
}

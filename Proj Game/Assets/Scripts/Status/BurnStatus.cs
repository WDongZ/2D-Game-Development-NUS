using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : Status
{
    GameObject burnEffect;
    public override void GetStatus(GameObject iObject)
    {
        Debug.Log("burn");
        if(iObject.tag == "Player" || iObject.tag == "Enemy")
        {
            if (iObject.name == "BOSS")
            {
                burnEffect = Instantiate(statusEffect, new Vector3(iObject.transform.position.x, iObject.transform.position.y + 5, 0), Quaternion.identity);
            }
            else
            {
                burnEffect = Instantiate(statusEffect, new Vector3(iObject.transform.position.x, iObject.transform.position.y + 1, 0), Quaternion.identity);
            }
            burnEffect.transform.parent = iObject.transform;
            burnEffect.GetComponent<BurnStatusEffect>().lastingTime = lastingTime;
            iObject.GetComponent<EntityAttribute>().GetStatus(this);
            iObject.GetComponent<EntityAttribute>().hurtFactor = 2;
        }
    }

    
}

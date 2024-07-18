using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownStatus : Status
{
    GameObject speedDownEffect;
    public override void GetStatus(GameObject iObject)
    {
        if (iObject.tag == "Player" || iObject.tag == "Enemy")
        {
            if (iObject.name == "BOSS")
            {
                speedDownEffect = Instantiate(statusEffect, new Vector3(iObject.transform.position.x, iObject.transform.position.y + 5, 0), Quaternion.identity);
            }
            else
            {
                speedDownEffect = Instantiate(statusEffect, new Vector3(iObject.transform.position.x, iObject.transform.position.y + 1, 0), Quaternion.identity);
            }
            speedDownEffect.transform.parent = iObject.transform;
            speedDownEffect.GetComponent<SpeedDownStatusEffect>().lastingTime = lastingTime;
            iObject.GetComponent<EntityAttribute>().moveSpeed = iObject.GetComponent<EntityAttribute>().moveSpeed * 0.5f;
            iObject.GetComponent<EntityAttribute>().GetStatus(this);
        }
    }


}

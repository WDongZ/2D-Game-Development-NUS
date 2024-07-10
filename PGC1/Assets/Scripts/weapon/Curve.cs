using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : Wand
{
    public int bulletNum = 4;
    public float spreadAngle = 20;
    protected override void Fire()
    {
        int halfbulletNum = bulletNum / 2;

        for(int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = muzzlePos.position;
            bullet.GetComponent<CurveBullet>().SetDamage(damage);

            if(bulletNum % 2 == 1)
            {
                bullet.transform.right = Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum), Vector3.forward) * direction;
            }
            else
            {
                 bullet.transform .right = Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum) + spreadAngle/2, Vector3.forward) * direction;
            }
            bullet.GetComponent<CurveBullet>().SetTargetPos(mousePos);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Wand
{
    public int bulletNum = 5;

    public float spreadAngle = 10;
    protected override void Fire()
    {
        int halfbulletNum = bulletNum / 2;

        for(int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
            bullet.transform.position = muzzlePos.position;
            bullet.GetComponent<Bullet>().SetDamage(damage);

            if(bulletNum % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum), Vector3.forward) * direction);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(spreadAngle * (i - halfbulletNum) + spreadAngle/2, Vector3.forward) * direction);
            }
        }

    }
}

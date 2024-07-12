using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private int count = 1;
    private float angle = 0;
    public GameObject bulletPrefab;
    public Color bulletColor;

    private void Start()
    {
        bulletColor = bulletPrefab.GetComponent<SpriteRenderer>().color;
    }

    public void Burst(float interval, Vector2 direction, Vector3 Spawndirection)
    {
        Spread(interval, direction, Spawndirection);
    }
    public void Spread(float interval, Vector2 direction, Vector3 Spawndirection)
    {
        SpreadFire(direction, Spawndirection);
    }

    private void SpreadFire(Vector2 direction, Vector3 Spawndirection)
    {
        int halfbulletNum = count / 2;
        for (int i = 0; i < count; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<SpriteRenderer>().color = bulletColor;
            bullet.transform.position = Spawndirection;
            //bullet.GetComponent<Bullet>().SetSpeed(direction);
            //bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
            //bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            if (count % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle * (i - halfbulletNum), Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
                bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle * (i - halfbulletNum) + angle / 2, Vector3.forward) * direction);
                bullet.GetComponent<Bullet>().SetTag(gameObject.tag);
                bullet.GetComponent<Bullet>().SetDamage(GetComponent<PlayerAttribute>().damage);
            }
        }
    }
    public void SetBullet(int count, float angle)
    {
        this.count = count;
        this.angle = angle;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public GameObject player;
    public float damage = 5;
    public float interval;
    public GameObject bulletPrefab;
    protected Transform muzzlePos;

    protected Vector2 direction;
    protected Vector2 mousePos;

    protected float timer;

    protected float flipY;

    public float burndamage =0;
    public float burninterval =0;

    //protected Animator animator;
    protected virtual void Start()
    {
        //animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");
        flipY = transform.localScale.y;
    }
    protected virtual void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(flipY, -flipY,1);
        }
        else
        {
            transform.localScale = new Vector3(flipY, flipY,1);
        }
        damage = player.GetComponent<Player>().atk;
        burndamage = player.GetComponent<Player>().buffdamage;
        burninterval = player.GetComponent<Player>().buffinterval;
        Shoot();
    }
    protected virtual void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
        transform.right = direction;//右方朝向鼠标
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(Input.GetMouseButton(0))
        {
            if(timer <= 0)
            {
                Fire();
                timer = interval;
            }
        }
    }

    protected virtual void Fire()
    {
        //动画

        GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        bullet.transform.position = muzzlePos.position;
        bullet.GetComponent<Bullet>().SetDamage(damage);
        bullet.GetComponent<Bullet>().SetSpeed(direction);
        if(burndamage != 0)
        {
            bullet.GetComponent<Bullet>().SetBurn(burndamage, burninterval);
        }
    }
}

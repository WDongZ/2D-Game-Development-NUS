using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public float interval;
    public float damage;
    public GameObject bulletPrefab;
    protected Transform muzzlePos;

    protected Vector2 direction;
    protected Vector2 mousePos;

    protected float timer;

    protected float flipY;

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

        //GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        bullet.GetComponent<Bullet>().SetSpeed(direction);
    }
}

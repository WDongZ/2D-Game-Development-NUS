using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Slider slider;
    public float hp = 100;
    private bool isHurt = false;
    private Animator anim;
    public float xOffset;
    public float yOffset;
    [SerializeField] private bool isDead;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        slider.value = hp;
        Vector3 Cpos = Camera.main.WorldToViewportPoint(transform.position);
        slider.transform.localPosition = new Vector3(Cpos.x * 1920 + xOffset, Cpos.y * 1080 + yOffset, 0);
        if(hp <= 0)
        {
            isDead = true;
            GetComponent<Collider2D>().enabled = false;
        }
        anim.SetBool("isHurt", isHurt);
        anim.SetBool("isDead", isDead);
    }

    public void GetHurt(GameObject attacker)
    {
        anim.Play("Enemy_Idel");
        isHurt = true;
        hp -= attacker.GetComponent<Bullet>().damage;
    }

    public void EndHurt()
    {
        isHurt = false;
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinCollision : MonoBehaviour
{
    private PlayerAttribute player;
    public AudioClip coinSound; // 引用音效文件
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>(); // 假设AudioSource在主摄像机上
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject.tag == "Player")
        {
            player.goldCoinNum++;
            audioSource.PlayOneShot(coinSound); // 播放音效
            Destroy(gameObject);
        }
    }
}

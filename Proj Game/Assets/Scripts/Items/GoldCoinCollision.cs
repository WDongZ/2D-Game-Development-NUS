using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinCollision : MonoBehaviour
{
    private PlayerAttribute player;
    public AudioClip coinSound; // ������Ч�ļ�
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>(); // ����AudioSource�����������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.gameObject.tag == "Player")
        {
            player.goldCoinNum++;
            audioSource.PlayOneShot(coinSound); // ������Ч
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private PlayerAttribute player;
    private int HP;
    private TMP_Text healCount;
    public GameObject DeadMenu;
    public GameObject WinMenu;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        healCount = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    void Update()
    {
        HP = (int)player.HP;
        healCount.text = "x " + HP;
    }
    public void GameOver()
    {
        DeadMenu.SetActive(true);
    }
    public void GameWin()
    {
        WinMenu.SetActive(true);
    }
}

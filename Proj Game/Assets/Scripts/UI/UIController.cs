using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private PlayerAttribute player;
    private int HP;
    private int HPUpbound;
    private int goldCoinNum;
    private TMP_Text goldCoinCount;
    public GameObject DeadMenu;
    public GameObject WinMenu;
    public TMP_Text itemText;
    private float timer = 0;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerAttribute>();
        goldCoinCount = transform.Find("GoldCount").GetComponent<TMP_Text>();
    }

    void Update()
    {
        HP = (int)player.HP;
        HPUpbound = (int)player.HPUpbound;
        goldCoinNum = player.goldCoinNum;
        goldCoinCount.text = "x " + goldCoinNum;
        #region "HealUI"
        GameObject.Find("Canvas/HealUI/01_E").SetActive(HPUpbound >= 2);
        GameObject.Find("Canvas/HealUI/02_E").SetActive(HPUpbound >= 4);
        GameObject.Find("Canvas/HealUI/03_E").SetActive(HPUpbound >= 6);
        GameObject.Find("Canvas/HealUI/04_E").SetActive(HPUpbound >= 8);
        GameObject.Find("Canvas/HealUI/05_E").SetActive(HPUpbound >= 10);
        GameObject.Find("Canvas/HealUI/06_E").SetActive(HPUpbound >= 12);
        GameObject.Find("Canvas/HealUI/07_E").SetActive(HPUpbound >= 14);
        GameObject.Find("Canvas/HealUI/08_E").SetActive(HPUpbound >= 16);
        GameObject.Find("Canvas/HealUI/09_E").SetActive(HPUpbound >= 18);
        GameObject.Find("Canvas/HealUI/10_E").SetActive(HPUpbound >= 20);
        GameObject.Find("Canvas/HealUI/11_E").SetActive(HPUpbound >= 22);
        GameObject.Find("Canvas/HealUI/12_E").SetActive(HPUpbound >= 24);
        GameObject.Find("Canvas/HealUI/13_E").SetActive(HPUpbound >= 26);
        GameObject.Find("Canvas/HealUI/14_E").SetActive(HPUpbound >= 28);
        GameObject.Find("Canvas/HealUI/15_E").SetActive(HPUpbound >= 30);
        GameObject.Find("Canvas/HealUI/16_E").SetActive(HPUpbound >= 32);
        GameObject.Find("Canvas/HealUI/0.5").SetActive(HP >= 1);
        GameObject.Find("Canvas/HealUI/1").SetActive(HP >= 2);
        GameObject.Find("Canvas/HealUI/1.5").SetActive(HP >= 3);
        GameObject.Find("Canvas/HealUI/2").SetActive(HP >= 4);
        GameObject.Find("Canvas/HealUI/2.5").SetActive(HP >= 5);
        GameObject.Find("Canvas/HealUI/3").SetActive(HP >= 6);
        GameObject.Find("Canvas/HealUI/3.5").SetActive(HP >= 7);
        GameObject.Find("Canvas/HealUI/4").SetActive(HP >= 8);
        GameObject.Find("Canvas/HealUI/4.5").SetActive(HP >= 9);
        GameObject.Find("Canvas/HealUI/5").SetActive(HP >= 10);
        GameObject.Find("Canvas/HealUI/5.5").SetActive(HP >= 11);
        GameObject.Find("Canvas/HealUI/6").SetActive(HP >= 12);
        GameObject.Find("Canvas/HealUI/6.5").SetActive(HP >= 13);
        GameObject.Find("Canvas/HealUI/7").SetActive(HP >= 14);
        GameObject.Find("Canvas/HealUI/7.5").SetActive(HP >= 15);
        GameObject.Find("Canvas/HealUI/8").SetActive(HP >= 16);
        GameObject.Find("Canvas/HealUI/8.5").SetActive(HP >= 17);
        GameObject.Find("Canvas/HealUI/9").SetActive(HP >= 18);
        GameObject.Find("Canvas/HealUI/9.5").SetActive(HP >= 19);
        GameObject.Find("Canvas/HealUI/10").SetActive(HP >= 20);
        GameObject.Find("Canvas/HealUI/10.5").SetActive(HP >= 21);
        GameObject.Find("Canvas/HealUI/11").SetActive(HP >= 22);
        GameObject.Find("Canvas/HealUI/11.5").SetActive(HP >= 23);
        GameObject.Find("Canvas/HealUI/12").SetActive(HP >= 24);
        GameObject.Find("Canvas/HealUI/12.5").SetActive(HP >= 25);
        GameObject.Find("Canvas/HealUI/13").SetActive(HP >= 26);
        GameObject.Find("Canvas/HealUI/13.5").SetActive(HP >= 27);
        GameObject.Find("Canvas/HealUI/14").SetActive(HP >= 28);
        GameObject.Find("Canvas/HealUI/14.5").SetActive(HP >= 29);
        GameObject.Find("Canvas/HealUI/15").SetActive(HP >= 30);
        GameObject.Find("Canvas/HealUI/15.5").SetActive(HP >= 31);
        GameObject.Find("Canvas/HealUI/16").SetActive(HP >= 32);
        #endregion
        if (itemText.enabled)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5)
            {
                itemText.enabled = false;
                timer = 0;
            }
        }
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

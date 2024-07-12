using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown;

    public bool roomLeft, roomRight, roomUp, roomDown;

    public Text text;

    public int stepToStart;

    public int doorNumber;

    public GameObject entityLayerl;
    void Start()
    {
        doorLeft.SetActive(roomLeft);
        doorRight.SetActive(roomRight);
        doorUp.SetActive(roomUp);
        doorDown.SetActive(roomDown);
    }

    public void UpdateRoom(float xOffset, float yOffset)
    {
        stepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));

        text.text = stepToStart.ToString();

        doorNumber = roomUp ? doorNumber + 1 : doorNumber;
        doorNumber = roomDown ? doorNumber + 1 : doorNumber;
        doorNumber = roomLeft ? doorNumber + 1 : doorNumber;
        doorNumber = roomRight ? doorNumber + 1 : doorNumber;
    }

}

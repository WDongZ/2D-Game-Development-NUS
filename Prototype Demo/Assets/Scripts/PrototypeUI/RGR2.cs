using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RGR2 : MonoBehaviour
{

    public enum Direction { up, down, left, right };
    public Direction direction;

    [Header("Room Info")]
    public GameObject roomPrefab;
    public int roomNumber;
    private GameObject endRoom;

    [Header("Position Control")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    public int maxStep;
    public List<Room> rooms = new List<Room>();

    List<GameObject> farRooms = new List<GameObject>();
    List<GameObject> lessFarRooms = new List<GameObject>();
    List<GameObject> oneWayRooms = new List<GameObject>();

    public WallType wallType;

    void Start()
    {
        Setrooms();
    }

    private void Setrooms()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());
            ChangePointPos();
        }


        endRoom = rooms[0].gameObject;
        foreach (var room in rooms)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}

            SetupRoom(room, room.transform.position);
        }
        FindEndRoom();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position, .2f, roomLayer));
    }

    public void SetupRoom(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), .2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), .2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), .2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), .2f, roomLayer);

        newRoom.UpdateRoom(xOffset, yOffset);

        switch (newRoom.doorNumber)
        {
            case 1:
                if (newRoom.roomUp) Instantiate(wallType.singleUp, roomPosition, Quaternion.identity);
                if (newRoom.roomDown) Instantiate(wallType.singleBottom, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft) Instantiate(wallType.singleLeft, roomPosition, Quaternion.identity);
                if (newRoom.roomRight) Instantiate(wallType.singleRight, roomPosition, Quaternion.identity);
                break;
            case 2:
                if (newRoom.roomLeft && newRoom.roomUp) Instantiate(wallType.doubleLU, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomRight) Instantiate(wallType.doubleLR, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomDown) Instantiate(wallType.doubleLB, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomUp) Instantiate(wallType.doubleUR, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomDown) Instantiate(wallType.doubleRB, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomUp) Instantiate(wallType.doubleUB, roomPosition, Quaternion.identity);
                break;
            case 3:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight) Instantiate(wallType.tripleLUR, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomDown) Instantiate(wallType.tripleLUB, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomDown && newRoom.roomRight) Instantiate(wallType.tripleLRB, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomUp && newRoom.roomRight) Instantiate(wallType.tripleURB, roomPosition, Quaternion.identity);
                break;
            case 4:
                Instantiate(wallType.fourDoors, roomPosition, Quaternion.identity);
                break;
        }
    }

    public void FindEndRoom()
    {
        for (int i = 0; i < rooms.Count; i++)
            maxStep = Mathf.Max(maxStep, rooms[i].stepToStart);

        foreach (var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            else if (room.stepToStart == maxStep - 1)
                lessFarRooms.Add(room.gameObject);
        }

        for (int i = 0; i < farRooms.Count; i++)
        {
            if (farRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(farRooms[i]);
        }

        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if (lessFarRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(lessFarRooms[i]);
        }

        if (oneWayRooms.Count != 0)
        {
            oneWayRooms.Sort((a, b) => (b.GetComponent<Room>().stepToStart - a.GetComponent<Room>().stepToStart));
            endRoom = oneWayRooms[0];
        }
        else
            endRoom = farRooms[Random.Range(0, farRooms.Count)];
    }

}


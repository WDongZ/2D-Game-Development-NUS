using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGenerator : MonoBehaviour
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
    public EnyityLayerType entityLayerType;
    public DecorateType decorateType;

    List<GameObject> entityLayers = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());

            ChangePointPos();
        }

        rooms[0].transform.Find("Mask").gameObject.SetActive(false);

        endRoom = rooms[0].gameObject;
        foreach (var room in rooms)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}

            SetupRoom(room, room.transform.position);
        }
        rooms[0].entityLayerl = null;
        foreach (var layer in entityLayers)
        {
            layer.SetActive(false);
        }
        FindEndRoom();
        GameObject bossL = Instantiate(entityLayerType.BossLayer, endRoom.transform.position, Quaternion.identity);
        endRoom.GetComponent<Room>().entityLayerl = bossL;
        bossL.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Restart();
        }
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        } while (Physics2D.OverlapCircle(generatorPoint.position,.2f,roomLayer));
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

        int randomDecorate = Random.Range(0, 3);

        switch (randomDecorate)
        {
            case 0:
                Instantiate(decorateType.FlameDecorateL201, roomPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(decorateType.FlameDecorateL202, roomPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(decorateType.FlameDecorateL203, roomPosition, Quaternion.identity);
                break;
        }

        int randomEntityLayer = Random.Range(0, 5);

        switch (randomEntityLayer)
        {
            case 0:
                GameObject eL0 = Instantiate(entityLayerType.FlameEntityLayerL201, roomPosition, Quaternion.identity);
                newRoom.entityLayerl = eL0;
                entityLayers.Add(eL0);
                break;
            case 1:
                GameObject eL1 = Instantiate(entityLayerType.FlameEntityLayerL202, roomPosition, Quaternion.identity);
                newRoom.entityLayerl = eL1;
                entityLayers.Add(eL1);
                break;
            case 2:
                GameObject eL2 = Instantiate(entityLayerType.FlameEntityLayerL203, roomPosition, Quaternion.identity);
                newRoom.entityLayerl = eL2;
                entityLayers.Add(eL2);
                break;
            case 3:
                GameObject eL3 = Instantiate(entityLayerType.FlameEntityLayerL204, roomPosition, Quaternion.identity);
                newRoom.entityLayerl = eL3;
                entityLayers.Add(eL3);
                break;
            case 4:
                GameObject eL4 = Instantiate(entityLayerType.FlameEntityLayerL205, roomPosition, Quaternion.identity);
                newRoom.entityLayerl = eL4;
                entityLayers.Add(eL4);
                break;
        }

    }

    public void FindEndRoom()
    {
        for(int i = 0; i < rooms.Count; i++)
            maxStep = Mathf.Max(maxStep, rooms[i].stepToStart);

        foreach (var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            else if (room.stepToStart == maxStep - 1)
                lessFarRooms.Add(room.gameObject);
        }

        for (int i = 0; i <farRooms.Count; i++)
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
[System.Serializable]
public class WallType
{
    public GameObject singleLeft, singleRight, singleUp, singleBottom,
        doubleLU, doubleLR, doubleLB, doubleUR, doubleUB, doubleRB,
        tripleLUR, tripleLUB, tripleURB, tripleLRB,
        fourDoors;
}

[System.Serializable]
public class DecorateType
{
    public GameObject FlameDecorateL201, FlameDecorateL202, FlameDecorateL203;
}

[System.Serializable]
public class EnyityLayerType
{
    public GameObject FlameEntityLayerL201, FlameEntityLayerL202, FlameEntityLayerL203, FlameEntityLayerL204, FlameEntityLayerL205, BossLayer;
}
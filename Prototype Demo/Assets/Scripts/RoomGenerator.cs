using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RoomGenerator : MonoBehaviour
{

    public enum Direction { up, down, left, right };
    public Direction direction;

    [Header("Room Info")]
    public GameObject roomPrefab;
    public GameObject basicRoom1; // BasicRoom1 预制体
    public GameObject basicRoom2; // BasicRoom2 预制体
    public GameObject player;

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
    public void SwitchToBasicRoom1()
    {
        roomPrefab = basicRoom1;
        SwitchWallG1();
        Debug.Log("Switched to BasicRoom1");
        deleteAllRoom();
        DestroyAllWallTypes();
        
        restart();
    }
    public void SwitchWallG1()
    {
        wallType.singleLeft = wallType.singleLeft1;
        wallType.singleRight = wallType.singleRight1;
        wallType.singleUp = wallType.singleUp1;
        wallType.singleBottom = wallType.singleBottom1;
        wallType.doubleLU = wallType.doubleLU1;
        wallType.doubleLR = wallType.doubleLR1;
        wallType.doubleLB = wallType.doubleLB1;
        wallType.doubleUR = wallType.doubleUR1;
        wallType.doubleUB = wallType.doubleUB1;
        wallType.doubleRB = wallType.doubleRB1;
        wallType.tripleLUR = wallType.tripleLUR1;
        wallType.tripleLUB = wallType.tripleLUB1;
        wallType.tripleURB = wallType.tripleURB1;
        wallType.tripleLRB = wallType.tripleLRB1;
        wallType.fourDoors = wallType.fourDoors1;
    }

    public void SwitchWallG2()
    {
        wallType.singleLeft = wallType.singleLeft2;
        wallType.singleRight = wallType.singleRight2;
        wallType.singleUp = wallType.singleUp2;
        wallType.singleBottom = wallType.singleBottom2;
        wallType.doubleLU = wallType.doubleLU2;
        wallType.doubleLR = wallType.doubleLR2;
        wallType.doubleLB = wallType.doubleLB2;
        wallType.doubleUR = wallType.doubleUR2;
        wallType.doubleUB = wallType.doubleUB2;
        wallType.doubleRB = wallType.doubleRB2;
        wallType.tripleLUR = wallType.tripleLUR2;
        wallType.tripleLUB = wallType.tripleLUB2;
        wallType.tripleURB = wallType.tripleURB2;
        wallType.tripleLRB = wallType.tripleLRB2;
        wallType.fourDoors = wallType.fourDoors2;
    }

    public void DestroyAllWallTypes()
    {
        DestroyInstances();
    }

    private void DestroyInstances()
    {
        GameObject[] instances = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject instance in instances)
        {
            Destroy(instance);
        }
    }



    public void deleteAllRoom()
    {
        foreach(var room in rooms)
        {
            Destroy(room.gameObject);
        }
        rooms.Clear();


    }
    public void restart()
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

        if (player != null)
        {
            player.transform.position = new Vector3(rooms[0].transform.position.x, rooms[0].transform.position.y, player.transform.position.z);
        }
        FindEndRoom();
    }


    public void SwitchToBasicRoom2()
    {
        roomPrefab = basicRoom2;
        SwitchWallG2();
        Debug.Log("Switched to BasicRoom2");
        deleteAllRoom();
        DestroyAllWallTypes();
        restart();
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
                if (newRoom.roomUp)
                {
                    GameObject wallInstance = Instantiate(wallType.singleUp, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomDown)
                {
                    GameObject wallInstance = Instantiate(wallType.singleBottom, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomLeft)
                {
                    GameObject wallInstance = Instantiate(wallType.singleLeft, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomRight)
                {
                    GameObject wallInstance = Instantiate(wallType.singleRight, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                break;
            case 2:
                if (newRoom.roomLeft && newRoom.roomUp)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleLU, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomLeft && newRoom.roomRight)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleLR, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomLeft && newRoom.roomDown)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleLB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomRight && newRoom.roomUp)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleUR, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomRight && newRoom.roomDown)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleRB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomDown && newRoom.roomUp)
                {
                    GameObject wallInstance = Instantiate(wallType.doubleUB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                break;
            case 3:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight)
                {
                    GameObject wallInstance = Instantiate(wallType.tripleLUR, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomDown)
                {
                    GameObject wallInstance = Instantiate(wallType.tripleLUB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomLeft && newRoom.roomDown && newRoom.roomRight)
                {
                    GameObject wallInstance = Instantiate(wallType.tripleLRB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                if (newRoom.roomDown && newRoom.roomUp && newRoom.roomRight)
                {
                    GameObject wallInstance = Instantiate(wallType.tripleURB, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
                break;
            case 4:
                if(true) {
                    GameObject wallInstance = Instantiate(wallType.fourDoors, roomPosition, Quaternion.identity);
                    wallInstance.tag = "Wall";
                }
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
    public GameObject singleLeft1, singleRight1, singleUp1, singleBottom1,
        doubleLU1, doubleLR1, doubleLB1, doubleUR1, doubleUB1, doubleRB1,
        tripleLUR1, tripleLUB1, tripleURB1, tripleLRB1,
        fourDoors1;
    public GameObject singleLeft2, singleRight2, singleUp2, singleBottom2,
        doubleLU2, doubleLR2, doubleLB2, doubleUR2, doubleUB2, doubleRB2,
        tripleLUR2, tripleLUB2, tripleURB2, tripleLRB2,
        fourDoors2;
    

}

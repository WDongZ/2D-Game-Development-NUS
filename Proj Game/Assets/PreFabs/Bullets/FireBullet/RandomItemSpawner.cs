using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    public Transform spawnLocation3;

    [SerializeField] private GameObject[] items;

    void Start()
    {
        List<GameObject> itemsList = new List<GameObject>(items);
        SpawnRandomItem(spawnLocation2, itemsList);
        SpawnRandomItem(spawnLocation3, itemsList);
    }

    void SpawnRandomItem(Transform spawnLocation, List<GameObject> itemsList)
    {
        int randomIndex = Random.Range(0, itemsList.Count);
        GameObject itemToSpawn = itemsList[randomIndex];
        Instantiate(itemToSpawn, spawnLocation.position, spawnLocation.rotation);
        itemsList.RemoveAt(randomIndex);
    }
}
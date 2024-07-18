using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    public Transform spawnLocation3;
    private GameObject prop1;
    private GameObject prop2;

    public List<GameObject> itemsList;

    void Start()
    {
        prop1 = SpawnRandomItem(spawnLocation2, itemsList);
        prop2 = SpawnRandomItem(spawnLocation3, itemsList);
    }

    private GameObject SpawnRandomItem(Transform spawnLocation, List<GameObject> itemsList)
    {
        int randomIndex = Random.Range(0, itemsList.Count);
        GameObject itemToSpawn = itemsList[randomIndex];
        itemsList.RemoveAt(randomIndex);
        return Instantiate(itemToSpawn, spawnLocation.position, spawnLocation.rotation);
    }

    public void ReRollItem()
    {
        Destroy(prop1);
        Destroy(prop2);
        prop1 = SpawnRandomItem(spawnLocation2, itemsList);
        prop2 = SpawnRandomItem(spawnLocation3, itemsList);
    }
}
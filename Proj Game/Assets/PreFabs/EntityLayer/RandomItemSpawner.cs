using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    public Transform spawnLocation3;

    [SerializeField] private GameObject[] items;

    void Start()
    {
        Debug.Log("item numbers: " + items);
        SpawnRandomItem(spawnLocation1);
        SpawnRandomItem(spawnLocation2);
        SpawnRandomItem(spawnLocation3);
    }


    void SpawnRandomItem(Transform spawnLocation)
    {
        int randomIndex = Random.Range(0, items.Length);
        GameObject itemToSpawn = items[randomIndex];

        Instantiate(itemToSpawn, spawnLocation.position, spawnLocation.rotation);
    }
}

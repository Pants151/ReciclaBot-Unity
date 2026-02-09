using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs; // Aquí arrastrará mis prefabs
    public float spawnRate = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnRate);
    }

    void SpawnObject()
    {
        int index = Random.Range(0, prefabs.Length);
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(prefabs[index], spawnPos, Quaternion.identity);
    }
}
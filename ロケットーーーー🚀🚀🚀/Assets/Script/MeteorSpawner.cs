using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float spawnInterval = 2f;

    public float minX = -8f;
    public float maxX = 8f;

    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f, spawnInterval);
    }

    void SpawnMeteor()
    {
        Vector3 pos = new Vector3(
            Random.Range(minX, maxX),
            spawnY,
            0
        );

        Instantiate(meteorPrefab, pos, Quaternion.identity);
    }
}
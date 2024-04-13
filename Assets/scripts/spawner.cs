using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public Vector3 spawnAreaSize = new Vector3(10f, 2f, 10f); // The size of the spawn area
    public int numberOfObjects = 10; // Number of objects to spawn
    public float minDistanceBetweenObjectsFeet = 2f; // Minimum distance between spawned objects in feet
    public float maxDistanceBetweenObjectsFeet = 3f; // Maximum distance between spawned objects in feet

    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Vector3 spawnAreaCenter = transform.position; // Use the position of this GameObject as the spawn area center

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculate random spawn position within the defined area
            Vector3 spawnPosition = GetValidSpawnPosition(spawnAreaCenter);

            // Spawn the object
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Add the spawn position to the list of spawned positions
            spawnedPositions.Add(spawnPosition);
        }
    }

    Vector3 GetValidSpawnPosition(Vector3 spawnAreaCenter)
    {
        Vector3 spawnPosition;
        bool isValid = false;

        // Keep generating random positions until a valid one is found
        do
        {
            isValid = true;
            spawnPosition = spawnAreaCenter + new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );

            // Check if the spawn position is too close to any existing object
            foreach (Vector3 pos in spawnedPositions)
            {
                float distance = Vector3.Distance(spawnPosition, pos) * 3.28084f;
                if (distance < minDistanceBetweenObjectsFeet || distance > maxDistanceBetweenObjectsFeet)
                {
                    isValid = false;
                    break;
                }
            }
        } while (!isValid);

        return spawnPosition;
    }

    // Draw gizmos for visualizing the spawn area in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}

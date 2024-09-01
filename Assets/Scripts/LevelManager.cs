using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<LevelPart> parts;
    [SerializeField] Transform player;       
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] int maxSpawnedParts = 3;

    private List<LevelPart> spawnedParts = new List<LevelPart>();
    private LevelPart lastSpawnedPart;

    void Start()
    {
        SpawnRandomLevel();
    }

    void Update()
    {
        if (lastSpawnedPart != null && Vector3.Distance(player.position, lastSpawnedPart.GetRightMidpointPosition()) < spawnDistance)
        {
            SpawnRandomLevel();

            if (spawnedParts.Count > maxSpawnedParts)
            {
                LevelPart partToDestroy = spawnedParts[0];
                spawnedParts.RemoveAt(0);
                Destroy(partToDestroy.gameObject);
            }
        }
    }

    public void SpawnRandomLevel()
    {
        LevelPart newPart = Instantiate(parts[Random.Range(0, parts.Count)]);
        Vector3 spawnPosition = Vector3.zero;

        if (lastSpawnedPart != null)
        {
            spawnPosition = lastSpawnedPart.GetRightMidpointPosition() + 
                            (newPart.transform.position - newPart.GetLeftMidpointPosition());
        }

        newPart.transform.position = spawnPosition;
        spawnedParts.Add(newPart);
        lastSpawnedPart = newPart;
    }
}

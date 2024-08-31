using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<LevelPart> parts;
    private LevelPart lastSpawnedPart;

    void Start()
    {
        SpawnRandomLevel();
        SpawnRandomLevel();
        SpawnRandomLevel();
        SpawnRandomLevel();

    }

    public void SpawnRandomLevel()
    {
        Vector3 spawnPosition = Vector3.zero;
        if (lastSpawnedPart != null)
        {
            spawnPosition = lastSpawnedPart.GetRightMidpointPosition();
        }

        LevelPart newPart = Instantiate(parts.Random(), spawnPosition, Quaternion.identity);
        lastSpawnedPart = newPart;
    }
}

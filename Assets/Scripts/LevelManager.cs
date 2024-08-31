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
        LevelPart newPart = Instantiate(parts.Random());

        Vector3 spawnPosition = Vector3.zero;
        if (lastSpawnedPart != null)
        {
            spawnPosition = lastSpawnedPart.GetRightMidpointPosition() + (newPart.transform.position - newPart.GetLeftMidpointPosition());
        }
        newPart.transform.position = spawnPosition;
        lastSpawnedPart = newPart;
    }
}

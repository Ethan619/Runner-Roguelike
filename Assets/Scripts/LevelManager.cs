using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<LevelPart> parts;

    void Start()
    {
        SpawnRandomLevel();
    }

    void SpawnRandomLevel()
    {
        Instantiate(parts.Random());
    }
}

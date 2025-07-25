using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepSpawnConfig", menuName = "Configs/Sheep Spawn Config")]
public class SheepSpawnConfig : ScriptableObject
{
    public Vector3[] spawnPositions;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyGroup 
{
    //[SerializeField]
    public GameObject prefab;
    [Tooltip("X - amount of enemies. Y ticks between spawns.")]
    public Vector2Int spawnRate; 

}

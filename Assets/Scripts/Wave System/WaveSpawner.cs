using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnPositions; 

    [SerializeField]
    WaveGroup[] waveGroups;

    //Should either Sub to LevelManager -> or report themeselves and then do nothing "of their own accord"

    public void SpawnWaveGroup()
    {

    }

    public void SpawnSingle()
    {

    }
}

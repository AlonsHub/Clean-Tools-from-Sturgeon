using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPositions; 

    [SerializeField]
    WaveGroup[] waveGroups;

    public bool IsSpawnning;

    //Should either Sub to LevelManager -> or report themeselves and then do nothing "of their own accord"
    private void Start()
    {
        LevelManager.Instance.RegisterWaveSpawner(this);
    }

    public void CallSpawnRandomWave()
    {
        StartCoroutine(nameof(SpawnRandomWaveGroup));
    }

    IEnumerator SpawnRandomWaveGroup()
    {
        Debug.Log($"{name} began spawning.");
        IsSpawnning = true;

        WaveGroup wg = Helper.GetRandomElementFromArray(waveGroups);

        foreach (var enemyGroup in wg.enemyGroups)
        {
            int rndSpawnPos = Random.Range(0, spawnPositions.Length);
            for (int i = 0; i < enemyGroup.spawnRate.x; i++)
            {
                GameObject go = Instantiate(enemyGroup.prefab, spawnPositions[rndSpawnPos]);
            }
            yield return new WaitForSeconds(enemyGroup.spawnRate.y);
        }
        Debug.Log($"{name} has finished spawning.");
        IsSpawnning = false;
    }
}

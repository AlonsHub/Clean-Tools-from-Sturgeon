using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaveGroup 
{
    public EnemyGroup[] enemyGroups;

    public void TickAllGroups()
    {
        foreach (var item in enemyGroups)
        {
            item.tick++;
        }
    }
}

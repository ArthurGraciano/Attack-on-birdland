using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private static int levelLimit = 10;
    private int enemySpawnedCount;
    public static RespawnController Instance;

    private Dictionary<int, int> respawnPerLevel = new Dictionary<int, int>();

    public static Dictionary<int, GameObject> enemiesDictionary = new Dictionary<int, GameObject>();

    private void Awake()
    {
        Instance = this;
        CreateEnemyDictionary();
        CalculateMaxEnemy();
    }



    void Start()
    {
        StartCoroutine(RespawnLoop());
        
    }


    IEnumerator RespawnLoop()
    {
        int level = GameController.Instance.Level;

        while (level == GameController.Instance.Level)
        {
            yield return new WaitForSeconds(1f);
            EnemyPerLevel(level);
        }
    }

    private void EnemyPerLevel(int level)
    {

        if (enemySpawnedCount < respawnPerLevel[level])
        {
            
            Instantiate(enemiesDictionary[1]);
            enemySpawnedCount++;
            
        }

        
    }

    private void CalculateMaxEnemy()
    {

        for (int i = 1; i <= levelLimit; i++)
        {
            respawnPerLevel.Add(i, 30 + ((i + i)* 2));
            Debug.Log(respawnPerLevel[i]);
        }

    }

    private void CreateEnemyDictionary()
    {
        enemiesDictionary.Add(1, new Enemy<Bird1>("Bird1").GameObject);
        enemiesDictionary.Add(2, new Enemy<Bird2>("Bird2").GameObject);
    }

}

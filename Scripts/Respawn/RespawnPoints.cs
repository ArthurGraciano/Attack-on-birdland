using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoints : MonoBehaviour
{
    private List<Vector2> respawnPointList = new List<Vector2>();
    public List<Vector2> RespawnPointList
    {
      get { return respawnPointList; }
      private set { RespawnPointList = respawnPointList; }
    }
    public static RespawnPoints RespawnPointsInstance;

    private void Awake() 
    {
        RespawnPointsInstance = this;
        GameObject[] respawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        foreach(GameObject point in respawnPoints)
        {
            respawnPointList.Add
                (new Vector2(point.transform.position.x, point.transform.position.y));
        }
    }
}

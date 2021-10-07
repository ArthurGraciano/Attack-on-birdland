using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private int _level = 1;
    public int Level
    {
      get { return _level; }
      private set { Level = _level; }
    }

    private void Awake() => Instance = this;


}

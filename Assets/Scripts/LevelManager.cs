using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform[] path;
    public Transform point;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
}

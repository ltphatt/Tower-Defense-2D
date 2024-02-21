using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform[] path;
    public Transform startPoint;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
}

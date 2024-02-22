using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    private int selectedTower = 0;

    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }

}

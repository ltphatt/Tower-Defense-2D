using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tower[] towers;
    [SerializeField] private Tower selectedTower;
    private int selectedTowerIndex = 0;

    public static BuildManager instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void Start()
    {
        selectedTower = new Tower();
        SetSelectedTower(0);
    }

    void Update()
    {
        selectedTower = GetSelectedTower();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public Tower GetSelectedTower()
    {
        return towers[selectedTowerIndex];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTowerIndex = _selectedTower;
    }
}

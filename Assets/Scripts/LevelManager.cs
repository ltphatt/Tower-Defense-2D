using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currency;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You do have enough money to buy new tower!!");
            return false;
        }
    }

    public int GetCurrency()
    {
        return currency;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;

    void Update()
    {
        currencyUI.text = $"Coins: {LevelManager.instance.currency}";
    }

    public void SetSelected()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;
    public static bool isMenuOpen = true;
    void Update()
    {
        currencyUI.text = $"Coins: {LevelManager.instance.currency}";
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("isOpenMenu", isMenuOpen);
    }
}

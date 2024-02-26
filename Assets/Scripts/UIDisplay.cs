using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;

    void Start()
    {
        healthSlider.maxValue = LevelManager.instance.playerHealth;
        Debug.Log("Start HP: " + LevelManager.instance.playerHealth.ToString());
    }

    void Update()
    {
        healthSlider.value = LevelManager.instance.playerHealth;
        Debug.Log(LevelManager.instance.playerHealth);
    }
}

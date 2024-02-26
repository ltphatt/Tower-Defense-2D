using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] Image fillImage;

    void Start()
    {
        healthSlider.maxValue = LevelManager.instance.playerHealth;
    }

    void Update()
    {
        healthSlider.value = LevelManager.instance.playerHealth;
        ModifyColorHPBar();
    }

    void ModifyColorHPBar()
    {
        int hp = LevelManager.instance.playerHealth;

        if (hp < 20)
        {
            fillImage.color = Color.red;
        }
        else if (hp < 60)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.green;
        }
    }
}

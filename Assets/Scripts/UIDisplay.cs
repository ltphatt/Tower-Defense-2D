using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] Image fillImage;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        healthSlider.maxValue = LevelManager.instance.playerHealth;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = $"Score: {scoreKeeper.GetScore().ToString("0000")}";
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

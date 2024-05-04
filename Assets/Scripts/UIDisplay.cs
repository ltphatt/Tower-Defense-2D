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
    [SerializeField] Image fillHP;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Enemy Wave")]
    [SerializeField] private Slider enemyWave;

    [Header("References")]
    EnemySpawner enemySpawner;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        healthSlider.maxValue = LevelManager.instance.playerHealth;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        enemyWave.maxValue = enemySpawner.GetWaveCount();
    }

    void Update()
    {
        scoreText.text = $"Score: {scoreKeeper.GetScore().ToString("0000")}";
        healthSlider.value = LevelManager.instance.playerHealth;
        enemyWave.value = enemySpawner.GetWaveSpawned();
        ModifyColorHPBar();
    }

    void ModifyColorHPBar()
    {
        int hp = LevelManager.instance.playerHealth;

        if (hp < 20)
        {
            fillHP.color = Color.red;
        }
        else if (hp < 60)
        {
            fillHP.color = Color.yellow;
        }
        else
        {
            fillHP.color = Color.green;
        }
    }

}

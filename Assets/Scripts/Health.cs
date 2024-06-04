using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int health = 3;
    [SerializeField] private int coinReward = 50;
    [SerializeField] private int scoreReward = 10;
    [SerializeField] ParticleSystem explosionEffect;
    ScoreKeeper scoreKeeper;

    public bool isDie = false;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        isDie = false;
    }

    void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDie = true;
        scoreKeeper.ModifyScore(scoreReward);
        LevelManager.instance.IncreaseCurrency(coinReward);
        AudioPlayer.instance.PlayDamageSound();
        LevelManager.instance.IncreasingEnemyKilled();

        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            TakeDamage(bullet.GetDamage());
            PlayExplosionEffect();
            Destroy(bullet.gameObject);
        }
    }

    void PlayExplosionEffect()
    {
        if (explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}

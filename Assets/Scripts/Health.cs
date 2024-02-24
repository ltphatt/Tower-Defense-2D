using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int health = 3;
    [SerializeField] private int reward = 50;
    [SerializeField] ParticleSystem explosionEffect;

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
        Destroy(gameObject);
        LevelManager.instance.IncreaseCurrency(reward);
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

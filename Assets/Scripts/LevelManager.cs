using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public const int MAX_HEALTH = 100;
    public static LevelManager instance;
    public int currency;
    public int playerHealth = 100;
    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;

    public int enemyKilled = 0;

    private void Awake()
    {
        ManageSingleton();
    }

    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        enemyKilled = 0;
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

    private void Update()
    {
        if (playerHealth <= 0)
        {
            GameManager.instance.GameOver();
            playerHealth = MAX_HEALTH;
        }
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

    public void DamagedByEnemy(int dmg)
    {
        playerHealth -= dmg;
        ShakeCamera();
        AudioPlayer.instance.PlayGateSound();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.PlayShakeCamera();
        }
    }

    public void IncreasingEnemyKilled()
    {
        enemyKilled++;
    }

    public void FinishLevel(int countEnemySpawned)
    {
        if (enemyKilled == countEnemySpawned)
        {
            int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScenceIndex + 1);
        }
    }

}

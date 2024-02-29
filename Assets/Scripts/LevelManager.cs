using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int currency;
    public int playerHealth = 100;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;

    private void Awake()
    {
        ManageSingleton();
        cameraShake = Camera.main.GetComponent<CameraShake>();
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
}

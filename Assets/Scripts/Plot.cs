using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    bool isOccupied = false;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        if (!isOccupied)
        {
            Tower builtTower = BuildManager.instance.GetSelectedTower();

            if (builtTower.cost > LevelManager.instance.currency)
            {
                Debug.Log("You can't afford this tower!");
                return;
            }

            LevelManager.instance.SpendCurrency(builtTower.cost);
            Instantiate(builtTower.prefab, transform.position, Quaternion.identity);
            isOccupied = true;
        }
    }
}

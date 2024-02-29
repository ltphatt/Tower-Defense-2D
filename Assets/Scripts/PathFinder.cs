using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PathFinder : MonoBehaviour
{
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    [Header("References")]
    EnemySpawner enemySpawner;

    [SerializeField] private int damageToPlayer = 10;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            // Move to next point
            Vector3 target = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, delta);

            // Chỉnh hướng xoay tại đây
            float angle = Mathf.Atan2(target.y - transform.position.y,
             target.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5f);

            if (transform.position == target)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            LevelManager.instance.DamagedByEnemy(damageToPlayer);
        }
    }

}

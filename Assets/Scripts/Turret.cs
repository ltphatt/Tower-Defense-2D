using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotatePoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float bulletPerSec = 2f;

    private Transform target = null;
    private float timeUntilFire;

    // Vẽ tầm bắn cho trụ
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bulletPerSec)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.SetTarget(target);
    }

    // Tìm mục tiêu
    void FindTarget()
    {
        // Trả về một mảng các đối tượng mà circle cast va chạm
        RaycastHit2D[] hits = Physics2D.CircleCastAll(
            transform.position, // Vị trí trung tâm của CircleCast (Vị trí của object mà script đính kèm)
            targetingRange,     // Bán kính CircleCast
            (Vector2)transform.position,    // Hướng của CircleCast
            0f,                             // Góc quay, 0f = full 1 vòng tròn
            enemyMask                       // Circle chỉ tương tác với mask enemy
        );

        // Nếu mảng hits chứa phần tử, phần tử đầu tiên sẽ là target cho trụ
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    // Hướng trụ về mục tiêu
    void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,
         target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotatePoint.rotation = Quaternion.RotateTowards(turretRotatePoint.rotation, targetRotation, rotateSpeed);
    }

    // Kiểm tra mục tiêu có trong tầm bắn không
    bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

}

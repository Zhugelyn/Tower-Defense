using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private Transform _shootingPoint;
    [SerializeField]
    private GameObject _bulletPrefab;

    private float _shootingRange = 14f;
    private float _shootingInterval = 1f;
    private float _lastShootTime;

    private void Start()
    {
        _lastShootTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _lastShootTime >= _shootingInterval)
        {
            GameObject nearestEnemy = FindNearestEnemy();

            if (nearestEnemy != null)
            {
                Shoot(nearestEnemy.transform);
            }

            _lastShootTime = Time.time;
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance <= _shootingRange)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    private void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(_bulletPrefab, _shootingPoint.position, Quaternion.identity);

        Vector3 direction = (target.position - _shootingPoint.position).normalized;
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}

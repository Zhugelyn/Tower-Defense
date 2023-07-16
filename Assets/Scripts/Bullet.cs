using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;
    private Vector3 _direction;
    private int _damage = 10;

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("Пуля попала во врага!");
            Destroy(gameObject);

            enemy.ReduceHealth(_damage);
            if (enemy.Health <= 0)
                Destroy(enemy.gameObject);
        }
    }
}
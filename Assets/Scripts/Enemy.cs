using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;
    public float Speed = 5;

    public Enemy(int health, float speed)
    {
        Health = health;
        Speed = speed;
    }

    private void IncreaseSpeed(float speed)
    {
        Speed += speed; 
    }

    private void SlowDown(float speed)
    {
        Speed -= speed;
    }

    public void ReduceHealth(int damage)
    {
       Health -= damage;
    }
}

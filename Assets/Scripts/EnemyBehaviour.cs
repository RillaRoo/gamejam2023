using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health = 3;

    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        return ;
    }
}

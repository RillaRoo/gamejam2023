using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float health;
    public float MaxHealth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;



    }

    // Update is called once per frame
   public void TakeDamage(int amount)
    {
        health += amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
   
}

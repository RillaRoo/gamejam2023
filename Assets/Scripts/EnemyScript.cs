using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   
    public PlayerScript playerheath;
    public int damage = -1;
    public float enemyHealth;
    public float maxEnemyHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxEnemyHealth;

    }

    // Update is called once per frame
    void Update()
    {



        
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mole")
        {

            //collision.gameObject.GetComponent<PlayerBottom>().TakeDamage(damage);
        }
        
    }
    public void TakeDamage(int amount)
    {
        enemyHealth += amount;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}

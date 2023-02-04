using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    [SerializeField] GameObject rgd1;
    int bulletDamage = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ant")
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }


}

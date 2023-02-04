using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ant")
        {
            collision.collider.gameObject.GetComponent<EnemyBehaviour>().ChangeHealth(-1);
        }
    }
}

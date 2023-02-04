using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x +speed, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ant")
        {
            collision.collider.gameObject.GetComponent<EnemyBehaviour>().ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}

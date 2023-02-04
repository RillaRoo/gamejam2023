using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField]  float speed=15f;
    void Start()
    {
        PlayerBottom mole = GameObject.FindGameObjectWithTag("Mole").GetComponent<PlayerBottom>();
        //rb2d.velocity = new Vector2(rb2d.velocity.x + speed * mole.dir.x, rb2d.velocity.y);
        rb2d.AddForce( new Vector2( speed* mole.dir, 0),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cimento")
        {
            anim.SetTrigger("Explode");
            Debug.Log(collision.gameObject.GetComponent<ConcreteBehaviour>().anim);
            collision.gameObject.GetComponent<ConcreteBehaviour>().anim.SetTrigger("Destroy");
        }
    }
}

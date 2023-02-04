using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField]  float speed=15f;
    [SerializeField] ParticleSystem psemi;
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
            rb2d.velocity = Vector2.zero;
            rb2d.isKinematic = true;
            anim.SetTrigger("Explode");
            psemi.Emit(1);
            Invoke("Destroy", 0.5f);
            collision.gameObject.GetComponent<ConcreteBehaviour>().anim.SetTrigger("Destroy");
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

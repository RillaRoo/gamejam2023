using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTop : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    private float speed = 5;
    private float inputX;

    GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bombSeed;
    public int bombAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if (GameObject.Find("Player") != null)
        {


            GameObject.Find("Player").GetComponent<Rigidbody2D>().position = new Vector2(0, 5);
        }

    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");



       
            rb2d.velocity = new Vector2(rb2d.velocity.x + speed * Time.deltaTime * inputX, rb2d.velocity.y);
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            GameObject enemy = Instantiate(bombSeed, firePoint.position, Quaternion.identity);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Areia")
        {
            animator.SetTrigger("Sink");
            Destroy(gameObject);
        }
    }
}

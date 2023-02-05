using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTreeCat : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] GameObject arvore;
    
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firepointUp;
    [SerializeField] Transform firepointDown;
    [SerializeField] PlayerBottom playerbottom;
    public  bool canClimb = false;
    float bulletSpeed = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float lastDir = -1;


        if (Input.GetKeyDown(KeyCode.I))
        {
           // GameObject arvore1 = Instantiate(arvore, point.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.W)&&canClimb)
        {

            //collision.gameObject.SetActive(false);
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + 20 * Time.deltaTime);
        }
       /* if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            fireUp();
        }
        else if(Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {

            fireDown();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerbottom.dir != 0)
            { 
                lastDir = playerbottom.dir;
                fire(lastDir);
            }
            
            fire(lastDir);  
        }*/
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Tronco")
        {
            canClimb = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tronco")
        {
            canClimb = false;
        }
        
    }
   

    public void fire(float lastDir)
    {
        GameObject bullett = Instantiate(bullet, firePoint.position, Quaternion.identity);
        if (playerbottom.dir == -1)
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (playerbottom.dir == 0 && lastDir == 1)
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(playerbottom.dir == 1 )
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(lastDir == -1)
        {
                bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(lastDir == 1)
        {
                bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        
        
        
    }
    public void fireUp()
    {
        GameObject bullett = Instantiate(bullet, firepointUp.position, Quaternion.identity);

        bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bullet.GetComponent<Rigidbody2D>().velocity.x, bulletSpeed);
    }
    public void fireDown()
    {
        GameObject bullett = Instantiate(bullet, firepointDown.position, Quaternion.identity);

        bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bullet.GetComponent<Rigidbody2D>().velocity.x, -bulletSpeed);
    }
}

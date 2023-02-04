using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private float imputX;
    private float imputY;
    
    [SerializeField] Rigidbody2D rgd1;
    [SerializeField] GameObject arvore;
    [SerializeField] Transform point;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firepointUp;
    [SerializeField] Transform firepointDown;
    [SerializeField] PlayerBottom playerbottom;
    float damage = -2;
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
            GameObject arvore1 = Instantiate(arvore, point.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.P)&&canClimb)
        {

            //collision.gameObject.SetActive(false);
            rgd1.velocity = new Vector2(rgd1.velocity.x, rgd1.velocity.y + 20 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Q) && Input.GetKey(KeyCode.UpArrow))
        {
            fireUp();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && Input.GetKey(KeyCode.DownArrow))
        {

            fireDown();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (playerbottom.dir != 0)
            { 
                lastDir = playerbottom.dir;
                fire(lastDir);
            }
            
            fire(lastDir);
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Tronco")
        {
            canClimb = true;
        }
        else
        {
            canClimb = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    private float imputX;
    private float imputY;
    
    [SerializeField] Rigidbody2D rgd1;
    [SerializeField] GameObject arvore;
    [SerializeField] GameObject arvoreVent;
    [SerializeField] Transform point;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firepointUp;
    [SerializeField] Transform firepointDown;
    [SerializeField] PlayerBottom playerbottom;
    [SerializeField] Animator Manimator;
    float damage = -2;
    public  bool canClimb = false;
    float bulletSpeed = 50;
    bool flag = true;
    float lastDir = 1;
    private float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject arvore1 = Instantiate(arvore, point.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject arvore1 = Instantiate(arvoreVent, point.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.P)&&canClimb)
        {
            Manimator.SetTrigger("CLimb");
            //collision.gameObject.SetActive(false);
            //rgd1.velocity = new Vector2(rgd1.velocity.x, rgd1.velocity.y + 20 * Time.deltaTime);
            rgd1.velocity = new Vector2(rgd1.velocity.x ,speed * Time.deltaTime);
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
            
            if(playerbottom.dir != 0)
            {
                fire(playerbottom.dir);
            }
            else if(playerbottom.dir == 0)
            {
                fire(lastDir);
            }


            



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
            Manimator.SetTrigger("ClimbOff");
        }
        if(collision.tag == "TroncoVent")
        {
            rgd1.velocity = new Vector2(rgd1.velocity.x, rgd1.velocity.y + 13 * Time.deltaTime);
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
        if (playerbottom.dir == -1)//certo
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (playerbottom.lastDir == 1)
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(playerbottom.dir == 1 )//certo
        {
            bullett.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bullett.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(playerbottom.lastDir == -1)
        {
            Debug.Log("Acertou");
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

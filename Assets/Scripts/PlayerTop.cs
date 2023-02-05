using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTop : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    private float speed = 250;
    private float inpuX;
    private float inputY;
    GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bomb;
    [SerializeField] SpriteRenderer moleSprite;
    public int bombAmount = 0;
    public float dir;
    private float lastDir;
    bool goingtoFlip;
    bool originalOrientation;
    Vector3 lastPos;
    Vector3 characterScale;
    float characterScaleX;
    // Start is called before the first frame update
    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;


    }

    // Update is called once per frame
    void Update()
    {

        inpuX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        if (inpuX != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

        rb2d.velocity = new Vector2(speed * Time.deltaTime * inpuX, rb2d.velocity.y);
        if (lastPos != null && lastPos != transform.position)
        {
            dir = Input.GetAxisRaw("Horizontal");

            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = -characterScaleX;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = characterScaleX;
            }
            transform.localScale = characterScale;

            //moleSprite.flipX= !moleSprite.flipX;
        }
        animator.SetFloat("VerticalLook", inputY);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetTrigger("Swing");
            GameObject bombproj = Instantiate(bomb, firePoint.position, Quaternion.identity);
            Debug.Log(transform.position);
            Debug.Log(dir);
            // enemy.GetComponent<EnemyBehaviour>().BeginPatrol();
        }
        lastPos = transform.position;
        if (dir != 0) lastDir = dir;

    }


}

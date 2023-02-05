using UnityEngine;

public class PlayerBottom : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    private float speed = 250;
    private float alternateInput;
    private float alternateInputY;
    GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bomb;
    [SerializeField] SpriteRenderer moleSprite;
    public int bombAmount = 0;
    public float dir;
    public float lastDir;
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
        Application.targetFrameRate = 60;
        if (GameObject.Find("Player") != null)
        {


            GameObject.Find("Player").GetComponent<Rigidbody2D>().position = new Vector2(0, 5);
        }

    }

    // Update is called once per frame
    void Update()
    {

        alternateInput = Input.GetAxis("HorizontalPlayer2");
        alternateInputY = Input.GetAxis("VerticalPlayer2");

        if (alternateInput != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else animator.SetBool("isWalking", false);

        rb2d.velocity = new Vector2(speed * Time.deltaTime * alternateInput, rb2d.velocity.y);
        if (lastPos != null && lastPos != transform.position)
        {
            dir = Input.GetAxisRaw("HorizontalPlayer2");

            if (Input.GetAxis("HorizontalPlayer2") < 0)
            {
                characterScale.x = -characterScaleX;
            }
            if (Input.GetAxis("HorizontalPlayer2") > 0)
            {
                characterScale.x = characterScaleX;
            }
            transform.localScale = characterScale;

            //moleSprite.flipX= !moleSprite.flipX;
        }
        animator.SetFloat("VerticalLook", alternateInputY);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetTrigger("Swing");
            GameObject bombproj = Instantiate(bomb, firePoint.position, Quaternion.identity);
            Debug.Log(transform.position);
            Debug.Log(dir);
            // enemy.GetComponent<EnemyBehaviour>().BeginPatrol();
        }
        lastPos = transform.position;
        if(dir!=0)lastDir = dir;

    }
   
    
}

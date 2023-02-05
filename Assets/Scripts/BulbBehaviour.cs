using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBehaviour : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField]  Rigidbody2D rb2d;
    [SerializeField] GameObject puzzle;
    [SerializeField] Transform puzzlespawnPoint;
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SurfaceGround")
        {
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
            Instantiate(tree, transform.position, Quaternion.identity);
            Instantiate(puzzle, puzzlespawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

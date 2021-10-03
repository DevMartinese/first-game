using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceJump;
    public GameManager gameManager;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("hisJump", true);
            rigidbody2d.AddForce(new Vector2(0, forceJump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("hisJump", false);
        }

        if (collision.gameObject.tag == "Stone")
        {
            gameManager.gameOver = true;
        }
    }
}

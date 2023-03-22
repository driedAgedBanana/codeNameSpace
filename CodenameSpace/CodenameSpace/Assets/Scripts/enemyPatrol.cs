using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D enemyRB;
    BoxCollider2D enemyBox; 
    public Animator Anim;
    bool Attacking;


    void Start()
    {
            enemyRB = GetComponent<Rigidbody2D>();
            enemyBox= GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!Attacking)
        {
            if (isFacingLeft())
            {
                //check for a wall in front of the enemy
                Vector2 rayOrigin = new Vector2(enemyBox.bounds.min.x - 0.1f, enemyBox.bounds.center.y);
                RaycastHit2D hitWall = Physics2D.Raycast(rayOrigin, Vector2.left, 0.2f, LayerMask.GetMask("Wall"));

                //check for ground beneath the enemy
                rayOrigin = new Vector2(enemyBox.bounds.center.x, enemyBox.bounds.min.y - 0.1f);
                RaycastHit2D hitGround = Physics2D.Raycast(rayOrigin, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));

                if (hitWall.collider != null || hitGround.collider == null)
                {
                    //change direction if a wall is detected or there is no ground beneath the enemy
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }

                //walk to the left
                if(!Attacking)
                {
                    enemyRB.velocity = new Vector2(moveSpeed, 0f);
                    print("WalkL");
                }

            }
            else
            {
                //check for a wall in front of the enemy
                Vector2 rayOrigin = new Vector2(enemyBox.bounds.max.x + 0.1f, enemyBox.bounds.center.y);
                RaycastHit2D hitWall = Physics2D.Raycast(rayOrigin, Vector2.right, 0.2f, LayerMask.GetMask("Wall"));

                //check for ground beneath the enemy
                rayOrigin = new Vector2(enemyBox.bounds.center.x, enemyBox.bounds.min.y - 0.1f);
                RaycastHit2D hitGround = Physics2D.Raycast(rayOrigin, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));

                if (hitWall.collider != null || hitGround.collider == null)
                {
                    //change direction if a wall is detected or there is no ground beneath the enemy
                    transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
                }

                //move to the left
                if (!Attacking)
                {
                    enemyRB.velocity = new Vector2(-moveSpeed, 0f);
                    print("Walk");
                }
            }
        }
        else
        {
            enemyRB.velocity = Vector2.zero;
        }
    }

    private bool isFacingLeft()
    {
        return transform.localScale.x < Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<Playermovement>())
        {
            Anim.SetBool("Attacking", false);
            Anim.SetBool("isWalking", true);
            Attacking = false;
        }
        else
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRB.velocity.x)), transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Playermovement>())
        {
            Anim.SetBool("isWalking", false);
            Anim.SetBool("Attacking", true);
            Attacking = true;
        }
    }
}

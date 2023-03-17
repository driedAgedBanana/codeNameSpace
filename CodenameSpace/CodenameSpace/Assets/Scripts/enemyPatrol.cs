using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
        [SerializeField] float moveSpeed = 5f;

        Rigidbody2D enemyRB;
        BoxCollider2D enemyBox;

        void Start()
        {
            enemyRB = GetComponent<Rigidbody2D>();
            enemyBox= GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            if (isFacingLeft())
            {
                //walk to the left
                enemyRB.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                //move to the left
                enemyRB.velocity = new Vector2(-moveSpeed, 0f);
            }
        }

        private bool isFacingLeft()
        {
            return transform.localScale.x < Mathf.Epsilon;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRB.velocity.x)), transform.localScale.y);
        }
    }

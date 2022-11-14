using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Math;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 13;
    public float accel = 0.8f;
    public float deccel = 2;
    public float deccelMod = 2;
    public float speed = 0;
    public float jumpHeight = 6.5f;

    public float speedVector = 0;
    float moveDirection = 0;
    float preSpeed = 0;
    float preMove = 0;
    public bool grounded = false;
    public bool frozen = false;
    Rigidbody2D r2d;
    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement direction
        if((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))){
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else{
            moveDirection = 0;
        }

        //Jump if allowed
        if (Input.GetKeyDown(KeyCode.W) && grounded && !frozen)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            frozen = !frozen;
            if (frozen)
            {
                preSpeed = speed;
                preMove = moveDirection;
                speed = 0;
                speedVector = 0;
                r2d.velocity = new Vector2(0, r2d.velocity.y);
                r2d.velocity = new Vector2(0, r2d.velocity.x);
                r2d.gravityScale = 0;
            }
            else
            {
                speed = preSpeed;
                moveDirection = preMove;
                speedVector = (moveDirection) * speed;

                r2d.velocity = new Vector2(speedVector, r2d.velocity.y);
                r2d.gravityScale = 1;
            }
        }
    }

    void FixedUpdate(){
        if (!frozen)
        {
            if (moveDirection == 0)
            {
                speed -= deccel;
                if (speedVector > 0)
                {
                    moveDirection = 1;
                }
                if (speedVector < 0)
                {
                    moveDirection = -1;
                }
            }
            else
            {
                if (((speedVector < 0) && (moveDirection < 0)) || ((speedVector > 0) && (moveDirection > 0)) || (speed == 0)) { speed += accel; }
                else
                {
                    speed -= deccelMod * deccel;
                    moveDirection = moveDirection * -1;
                }
            }

            speed = Max(speed, 0);
            speed = Min(speed, maxSpeed);
            speedVector = (moveDirection) * speed;

            r2d.velocity = new Vector2(speedVector, r2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            die();
        }
    }
     
    void die()
    {
        timer.GetComponent<Timer>().reset();
    }
}

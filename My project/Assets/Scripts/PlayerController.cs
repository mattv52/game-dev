using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Math;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 4;
    public float accel = 0.4f;
    public float deccel = 2;
    public float deccelMod = 2;
    public float speed = 0;
    public float jumpHeight = 5;
    public float voidDepth = -10;

    public float speedVector = 0;
    float moveDirection = 0;
    float preSpeed = 0;
    float preMove = 0;
    public bool grounded = false;
    public bool frozen = false;
    bool canDouble = false;
    public bool touchingSlime = false;
    public GameObject tint;
    Rigidbody2D r2d;
    SpriteRenderer sr;
    public AudioSource pewOn; 
    public AudioSource pewOff; 


    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < voidDepth) {SceneManager.LoadScene(SceneManager.GetActiveScene().name);}

        //Get movement direction
        if((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))){
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            if(!frozen) sr.flipX = moveDirection == -1 ? true : false;
        }
        else{
            moveDirection = 0;
        }

        //Jump if allowed
        if (Input.GetKeyDown(KeyCode.W) && grounded && !frozen)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            grounded = false;
            touchingSlime = false;
        }
        else if(Input.GetKeyDown(KeyCode.W) && canDouble && !frozen)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            canDouble = false;
        }

        //Freeze controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            frozen = !frozen;
            tint.SetActive(frozen);
            if (frozen)
            {
                pewOn.Play(0);
                preSpeed = speed;
                preMove = moveDirection;
                speed = 0;
                speedVector = 0;
                if (touchingSlime){
                    speedVector = (moveDirection) * preSpeed;
                    r2d.velocity = new Vector2(speedVector, r2d.velocity.y);
                }
                else {
                    r2d.velocity = new Vector2(0, r2d.velocity.y);
                    r2d.velocity = new Vector2(0, r2d.velocity.x);
                    r2d.gravityScale = 0;
                }
            }
            else
            {
                pewOff.Play(0);
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
        else
        {
            if (touchingSlime)
            {
                speedVector = (preMove) * preSpeed;
                r2d.velocity = new Vector2(speedVector, r2d.velocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            canDouble = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "Slime")
        {
            touchingSlime = true;
        }
    }
}
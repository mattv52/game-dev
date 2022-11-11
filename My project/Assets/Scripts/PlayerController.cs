using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 3.4f;
    float moveDirection = 0;
    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))){
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else{
            moveDirection = 0;
        }
    }

    void FixedUpdate(){
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }

}

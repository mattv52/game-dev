using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

    // Check for collision with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision is with Player
        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     collision.gameObject.GetComponent<Player>().GameOver();
        // }
    }
}

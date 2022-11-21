using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public SpriteRenderer sr;

    public GameObject target;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    public GameObject player;

    public float moveSpeed;
    private bool movingToTarget;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = target.transform.position;
        movingToTarget = true;
    }

	// Update is called once per frame
	void Update()
	{
		if(player.GetComponent<PlayerController>().frozen)
		{
			// Logic for moving between 2 points
			if(movingToTarget)
			{
				sr.flipX = false;
				transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
				if (transform.position == targetPosition) movingToTarget = false;
			} else 
			{
				sr.flipX = true;
				transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
				if (transform.position == startPosition) movingToTarget = true;
			}
		}
	}
}

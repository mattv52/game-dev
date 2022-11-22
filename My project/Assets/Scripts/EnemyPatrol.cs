using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public SpriteRenderer sr;

    public GameObject target;
    private Vector3 targetPosition;
    private Vector3 coltargetPosition;
    private Vector3 startPosition;
    private Vector3 colstartPosition;
    public GameObject player;
    public GameObject col;

    public float moveSpeed;
    private bool movingToTarget;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        colstartPosition = col.transform.position;
        targetPosition = target.transform.position;
        coltargetPosition = targetPosition;
        coltargetPosition.y = colstartPosition.y; 
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
				col.transform.position = Vector3.MoveTowards(col.transform.position, coltargetPosition, moveSpeed * Time.deltaTime);
				if (transform.position == targetPosition) movingToTarget = false;
			} else 
			{
				sr.flipX = true;
				transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
				col.transform.position = Vector3.MoveTowards(col.transform.position, colstartPosition, moveSpeed * Time.deltaTime);
				if (transform.position == startPosition) movingToTarget = true;
			}
			// col.transform.position.x = this.transform.position.x;
		}
	}
}
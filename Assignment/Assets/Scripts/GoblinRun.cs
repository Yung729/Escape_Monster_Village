using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRun : MonoBehaviour
{
	public float speed = 2.5f;
	public float attackRange = 3f;
	private Animator anim;

	Transform player;
	Rigidbody2D rb;
	GoblinFacing goblin;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = anim.GetComponent<Rigidbody2D>();
		goblin = anim.GetComponent<GoblinFacing>();

	}

	void Update()
	{
   	 	goblin.FlipDirection();

		Vector2 target = new Vector2(player.position.x, rb.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		rb.MovePosition(newPos);

		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			anim.SetTrigger("Attack");
		}
        else
        {
			anim.ResetTrigger("Attack");
		}
	}

}

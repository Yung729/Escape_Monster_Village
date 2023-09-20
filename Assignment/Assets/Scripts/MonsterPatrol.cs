using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                anim.SetBool("isRunning", true);
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 1;
            }
        }

        if (patrolDestination == 1)
        {
            anim.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 0;
            }
        }

    }

}



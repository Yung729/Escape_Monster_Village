using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;        //target transform component
    public float moveSpeed = 1;     //Enemy move speed
    public Animator animator;       //Enemy animator component

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //call the followTarget function
        followTarget();
    }

    private void followTarget()
    {
        //get the distance by minus the enemy position with the target position
        Vector3 distance = target.position - transform.position;

        //if the target is not null
        if (target != null)
        {
            //move the enemy to the target in x
            transform.Translate(new Vector3(distance.x, 0, 0) * moveSpeed * Time.deltaTime);


            //if x position, move right,else move left
            if (distance.x > 0)
                //set animator moveDir parameter to play more right animation
                animator.SetInteger("moveDir", 1);
            else
                //set animator moveDir parameter to play more left animation
                animator.SetInteger("moveDir", 2);
        }

    }
}

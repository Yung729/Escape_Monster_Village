using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 1;     //enemy move  speed
    public Animator animator;       //enemy animator component
    //float xRight;                 //To store Screen width - enemy sprite width
    float moveDis = 1;              //absolute move distance
    Vector3 localScale;             //enemy local scale
    bool isMoveRight = true;        //whether enemy is moving right
    // Start is called before the first frame update
    void Start()
    {
        //get the enemy local scale from the transform component
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
            // xRight = Screen width - enemny sprite width
            moveDis = (Screen.width - 32) / 100;

            // if reach xRight, set move right to false
            if (transform.position.x > moveDis) //(xRight){
                isMoveRight = true;

            // if reach -xRight, set move right to true
            if (transform.position.x < -moveDis) //(-xRight){
                isMoveRight = false;

            if (isMoveRight)
                moveRight();
            else
                moveLeft();
        } while (moveDis < -35.84);
    }

    void moveRight()
    {
        isMoveRight = true;                 //set move right to true
        localScale.x = 1;                   //assign the local scale to positive for right
        transform.localScale = localScale;  //set the zombie object local scale 
    }

    void moveLeft()
    {
        isMoveRight = false;                //set move right to false
        localScale.x = -1;                  //assign the local scale to negative for left
        transform.localScale = localScale;  //set the zombie object local scale
    }
}


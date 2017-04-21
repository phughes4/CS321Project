using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{
    public float speed = 5;
    public float distance = 10;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;

    Vector2 moveDir = new Vector2(0, 0);
    Vector2 oldDir;
    static Vector2 currentDir = new Vector2(0, 0);
    bool isMoving = false;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            //Debug.Log("NOT MOVING");
            moveDir = getEndPosition();
            
            //if(moveDir != oldDir)
            //isMoving = true;
        }
        if (isMoving)
        {
            //Debug.Log("MOVING");
        }
    }

    protected Vector2 getEndPosition()
    {
        Vector2 currentPosition = rb2d.position;

        Vector2 movement;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement = new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement = new Vector2(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = new Vector2(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = new Vector2(-1, 0);
        }
        else
        {
            movement = new Vector2(0, 0);
        }

        Vector2 finalPosition = currentPosition + movement;
        return finalPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "redGoal")
        {
            Debug.Log("onRed");
        }
        else if (collision.tag == "greenGoal")
        {
            Debug.Log("onGreen");
        }
        Debug.Log("ON GOAL");
    }


}

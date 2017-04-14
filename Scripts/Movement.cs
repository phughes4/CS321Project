using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveTime = 0.1f;
    private float inverseMoveTime;
    
    public float speed = 5;
    public float distance = 10;
 

    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;

    Vector2 blockPosition = new Vector2(0, 0);
    //static Vector2 currentDir = new Vector2(0, 0);
    bool isMoving = false;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;
    }

    // Update is called once per frame
    void Update()
    {
 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);


        if (!isMoving)
        {
            
            //Debug.Log("NOT MOVING");
            if (Input.GetKeyDown(KeyCode.LeftArrow) ^ Input.GetKeyDown(KeyCode.RightArrow) ^
               Input.GetKeyDown(KeyCode.UpArrow) ^ Input.GetKeyDown(KeyCode.DownArrow))
            {

                blockPosition = getEndPosition();
                Debug.Log(rb2d.tag+" can now move");
                isMoving = true;
            }
        }
        else if (isMoving)
        {
            //Debug.Log("MOVING");
            if (rb2d.position != blockPosition)
            {
                boxCollider.enabled = false;
                float box_x = Mathf.RoundToInt(boxCollider.transform.position.x);
                float box_y = Mathf.RoundToInt(boxCollider.transform.position.y);
                transform.position  = new Vector2(box_x, box_y);
                StartCoroutine(SmoothMovement(blockPosition)); 
                boxCollider.enabled = true;
            }
            
            isMoving = false;
            
        }

    }

    protected Vector2 getEndPosition()
    {
        
        //Debug.Log("rounded: " + box_x + " " + box_y);

        Vector2 currentPosition = rb2d.position;
        LayerMask mask = LayerMask.GetMask("foreground");
        boxCollider.enabled = false;

        //Debug.Log("current position:" + currentPosition);
        Vector2 checkPos;
        Vector2 movement;

        RaycastHit2D hit;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement = new Vector2(0, 1);
            checkPos = currentPosition + movement;
            Debug.Log("checkPos: " +checkPos);
            hit = Physics2D.Raycast(currentPosition, Vector2.up, Mathf.Infinity, mask.value, -Mathf.Infinity, Mathf.Infinity);
            Debug.Log(hit.collider.transform.position.x +" "+ hit.collider.transform.position.y);
            if (checkPos == new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y))
            {
                Debug.Log(rb2d.tag + " can't move");
                return currentPosition;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement = new Vector2(0, -1);
            checkPos = currentPosition + movement;
            Debug.Log("checkPos: " + checkPos);
            hit = Physics2D.Raycast(currentPosition, Vector2.down, Mathf.Infinity, mask.value, -Mathf.Infinity, Mathf.Infinity);
            if (checkPos == new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y))
            {
                Debug.Log(rb2d.tag + " can't move");
                return currentPosition;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = new Vector2(1, 0);
            checkPos = currentPosition + movement;
            Debug.Log("checkPos: " + checkPos);
            hit = Physics2D.Raycast(currentPosition, Vector2.right, Mathf.Infinity, mask.value, -Mathf.Infinity, Mathf.Infinity);
            if (checkPos == new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y))
            {
                Debug.Log(rb2d.tag + " can't move");
                return currentPosition;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = new Vector2(-1, 0);
            checkPos = currentPosition + movement;
            Debug.Log("checkPos: " + checkPos);
            hit = Physics2D.Raycast(currentPosition, Vector2.left, Mathf.Infinity, mask.value, -Mathf.Infinity, Mathf.Infinity);
            if (checkPos == new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y))
            {
                Debug.Log(rb2d.tag+" can't move");
                return currentPosition;
            }
        }
        else
        {
            movement = new Vector2(0, 0);
        }

        Vector2 finalPosition = currentPosition + movement;
        boxCollider.enabled = true;
        return finalPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == rb2d.tag)
        {
            Debug.Log(rb2d.tag + " on correct goal");
        }
        else 
        {
            Debug.Log(rb2d.tag + " on wrong goal");
        }

    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //Debug.Log(sqrRemainingDistance);
        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2d.position, end, inverseMoveTime * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2d.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
}

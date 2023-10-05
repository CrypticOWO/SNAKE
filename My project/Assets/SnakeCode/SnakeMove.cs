using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    //Variables
    private Vector2 direction; //control dirction of movement
    public bool goingUp;
    public bool goingDown;
    public bool goingLeft;
    public bool goingRight;

    List<Transform> segments; //variable to store all the parts of the snake body
    public Transform bodyPrefab;//variable to store the body

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();       //Creates a new list
        segments.Add(transform);                //Add the head of the snake to the list
    }

    // Update is called once per frame
    void Update()
    {
        //Change direction of snake
        if (Input.GetKeyDown(KeyCode.W) && goingDown != true)    //When W is pressed
        {
            direction = Vector2.up;          //Go Up
            goingUp = true;
            goingDown = false;
            goingLeft = false;
            goingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))    //When A is pressed
        {
            direction = Vector2.left;          //Go Left
            goingUp = false;
            goingDown = false;
            goingLeft = true;
            goingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && goingUp != true)    //When S is pressed
        {
            direction = Vector2.down;          //Go Down
            goingUp = false;
            goingDown = true;
            goingLeft = false;
            goingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))    //When D is pressed
        {
            direction = Vector2.right;          //Go Right
            goingUp = false;
            goingDown = false;
            goingLeft = false;
            goingRight = true;
        }
    }

    //FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        //move to the body of the snake
        for (int i = segments.Count - 1; i > 0; i--)                   //For each segment of the snake
        {
            segments[i].position = segments[i - 1].position;            //move the body
        }

        //move the snake
        this.transform.position = new Vector2(                          //Get the position
            Mathf.Round(this.transform.position.x) + direction.x,       //Round the number to add value to X
            Mathf.Round(this.transform.position.y) + direction.y        //Round the number to add value to Y
            );
    }

    //Function to make the snake grow
    void Grow()
    {
        Transform segment = Instantiate(this.bodyPrefab);               //Create a new body part
        segment.position = segments[segments.Count - 1].position;       //Position it on the back of the snake
        segments.Add(segment);                                          //Add it to the list
    }

    //Function for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Wall")
        {
            SceneManager.LoadScene("EndScene"); //changes to the end scene when hitting obstacle
        }
    }
}

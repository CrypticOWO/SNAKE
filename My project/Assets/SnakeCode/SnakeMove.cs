using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    //Variables
    private Vector2 direction; //control dirction of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change direction of snake
        if (Input.GetKeyDown(KeyCode.W))    //When W is pressed
        {
            direction = Vector2.up;          //Go Up
        }
        if (Input.GetKeyDown(KeyCode.A))    //When A is pressed
        {
            direction = Vector2.left;          //Go Left
        }
        if (Input.GetKeyDown(KeyCode.S))    //When S is pressed
        {
            direction = Vector2.down;          //Go Down
        }
        if (Input.GetKeyDown(KeyCode.D))    //When D is pressed
        {
            direction = Vector2.right;          //Go Right
        }
    }

    //FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        this.transform.position = new Vector2(                          //Get the position
            Mathf.Round(this.transform.position.x) + direction.x,       //Round the number to add value to X
            Mathf.Round(this.transform.position.y) + direction.y        //Round the number to add value to Y
            );
    }
}

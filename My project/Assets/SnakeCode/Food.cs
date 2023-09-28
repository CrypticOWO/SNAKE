using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //variables
    public BoxCollider2D Grid;      //Defines the grid as a dependant potential spawning space for food

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();                //Randomizes position of food at the start of game
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to randomize the position of the food
    private void RandomPos()
    {
        Bounds bounds = Grid.bounds;                                                //Declare the limits of the space

        float x = Random.Range(bounds.min.x, bounds.max.x);                      //Gives a random value to x within the limit
        float y = Random.Range(bounds.min.y, bounds.max.y);                      //Gives a random value to y within the limit

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));           //Round the values of x & y while changing position of food
    }

    //Function for movement every time snake collides with food
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomPos();
        }
    }
}

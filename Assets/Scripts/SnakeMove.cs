using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    private Vector2 direction;
    bool goingUp;
    bool goingLeft;
    bool goingDown;
    bool goingRight;

    //body variable 
    List<Transform> segments;        //variable to store the parts of the snake


    public Transform bodyPrefab;       //place to s tore the body

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();  // create a new list

        segments.Add(transform);        //Add the head of the snake to the list

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && goingDown != true)
        {
            direction = Vector2.up;
            goingUp = true;
            goingLeft = false;
            goingDown = false;
            goingRight = false;
        }

        else if (Input.GetKeyDown(KeyCode.A) && goingRight == false)
        {
            direction = Vector2.left;
            goingUp = false;
            goingLeft = true;
            goingDown = false;
            goingRight = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.S) && goingUp != true)
        {
            direction = Vector2.down;
            goingUp = false;
            goingLeft = false;
            goingDown = true;
            goingRight = false;
        }

        else if (Input.GetKeyDown(KeyCode.D) && goingLeft == false)
        {
            direction = Vector2.right;
            goingUp = false;
            goingLeft = false;
            goingDown = false;
            goingRight = true;
        }
    }
    void FixedUpdate()
    {
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments [i - 1].position;
        }


        transform.position = new Vector2 
        (Mathf.Round(transform.position.x) + direction.x,
        Mathf.Round(transform.position.y) + direction.y);
    }

    void Grow()
    {
       Transform segment = Instantiate(bodyPrefab);

       segment.position = segments[segments.Count - 1].position;
       segments.Add(segment);
       
    }



    void OnTriggerEnter2D (Collider2D other)
    {
       //if (CompareTag("Food"))
      //  {
       // direction = Vector2.zero;

       // Debug.Log("hit");
      //  }

        if (other.tag == "Food")
        {
            Debug.Log ("hit");
            Grow();

            Time.fixedDeltaTime -= 0.001f;
        }

        else if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("EndScene");
        }
    }  
}




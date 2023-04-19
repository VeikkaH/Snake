using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    void reset()
    {
        transform.SetPositionAndRotation(new Vector2(-0.48f, -0.3f), // Set start point, f for float
            Quaternion.Euler(0, 0, -90));                            // Point Snake right
        direction = Vector2.right;
        Time.timeScale = 0.05f;
    }
    // Update is called once per frame
    void Update()
    {
        getUserInput();
    }

    void getUserInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            reset();
        }
    }
    void FixedUpdate()
    {
        moveSnake();
    }

    void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }
}

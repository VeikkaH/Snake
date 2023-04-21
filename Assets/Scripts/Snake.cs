using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direction;
    public GameObject segment;
    public List<GameObject> segments = new List<GameObject>();
    public bool IsGamePaused { get; private set; } // For collision PlayMode Testing
    public bool IsTesting { get; set; }            // For collision PlayMode Testing

    void Start()
    {
        reset();
    }

    void reset()
    {
        transform.SetPositionAndRotation(new Vector2(0f, 0f),    // Set start point, f for float
            Quaternion.Euler(0, 0, -90));                        // Point Snake right
        direction = Vector2.right;
        Time.timeScale = 0.1f;
        IsGamePaused = false;
        resetSegments();
    }

    void resetSegments()
    {
        for (int i = 1; i<segments.Count; i++)  // Remove all segments
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();            // Clear the list
        segments.Add(gameObject);    // Add the Snake head

        for (int i = 0; i < 3; i++)  // Add 3 starter segments
        {
            grow();
        }
    }
    void grow()
    {
        if (segment != null)
        {
            GameObject newSegment = Instantiate(segment);
            newSegment.transform.position = segments[segments.Count - 1].transform.position;
            segments.Add(newSegment);
        }
    }
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
        moveSegments();
        moveSnake();
    }

    void moveSegments()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }
    void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collision")
        {
            IsGamePaused = true;

            if (!IsTesting)
            {
                Time.timeScale = 0;
            }

        } else if (other.tag == "Food")
        {
            grow();
        }
    }
}

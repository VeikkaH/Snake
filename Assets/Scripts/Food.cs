using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Start()
    {
        randomPosition();
    }
    void randomPosition()
    {
        int x, y;
        Vector2 newPosition;
        do
        {
            x = Random.Range(-6, 7);
            y = Random.Range(-6, 6);
            newPosition = new Vector2(x, y);
        } while (isPositionOccupied(newPosition));
        transform.position = newPosition;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        randomPosition();
    }
    bool isPositionOccupied(Vector2 position)
    {
        Snake snake = FindObjectOfType<Snake>();
        if (snake != null)
        {
            foreach (GameObject segment in snake.segments)
            {
                if ((Vector2)segment.transform.position == position)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

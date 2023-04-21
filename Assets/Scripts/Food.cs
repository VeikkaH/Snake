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
        int x = Random.Range(-6, 7);
        int y = Random.Range(-6, 6);
        transform.position = new Vector2(x, y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        randomPosition();
    }
}

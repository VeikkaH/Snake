using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction;

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
        
    }
}

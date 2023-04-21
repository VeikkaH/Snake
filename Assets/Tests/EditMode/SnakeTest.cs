using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpawnTest
{
    [Test]
    public void SpawnPosition()
    {   
        // ARRANGE
        var gameObject = new GameObject();
        var snake = gameObject.AddComponent<Snake>();
        
        // ACT
        snake.transform.SetPositionAndRotation(new Vector2(0f, 0f),
            Quaternion.Euler(0, 0, -90));

        // ASSERT
        Assert.AreEqual(snake.transform.position, new Vector3(0f, 0f, 0f));

    }
    
    [Test]
    public void SpawnRotation()
    {
        // ARRANGE
        var gameObject = new GameObject();
        var snake = gameObject.AddComponent<Snake>();

        // ACT
        snake.transform.SetPositionAndRotation(new Vector2(0f, 0f),
            Quaternion.Euler(0, 0, -90));

        // ASSERT
        Assert.AreEqual(snake.transform.rotation.eulerAngles.x, 0);
        Assert.AreEqual(snake.transform.rotation.eulerAngles.y, 0);
        Assert.AreEqual(snake.transform.rotation.eulerAngles.z, 270);

    }
}

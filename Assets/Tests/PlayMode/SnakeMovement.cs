using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SnakeMovement
{
    [UnityTest]
    public IEnumerator SnakeMoves()
    {
        var gameObject = new GameObject();
        var snake = gameObject.AddComponent<Snake>();
        snake.transform.SetPositionAndRotation(new Vector2(0f, 0f),
            Quaternion.Euler(0, 0, -90));

        yield return new WaitForSeconds(0.07f);    // Let Snake move

        Assert.AreNotEqual(snake.transform.position, new Vector3(0f, 0f, 0)); // Snake has moved from start position
    }
}

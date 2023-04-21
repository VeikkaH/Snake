using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SnakeTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator SnakeSelfCollisionTest()
    {
        Snake snake = GameObject.FindObjectOfType<Snake>();
        snake.IsTesting = true;                 // Make game not pause on collision
        snake.direction = Vector2.left;

        yield return new WaitForSeconds(0.1f);
        snake.direction = Vector2.right;

        yield return new WaitForSeconds(0.05f);

        Assert.IsTrue(snake.IsGamePaused);
    }
    [UnityTest]
    public IEnumerator SnakeWallCollisionTest()
    {
        Snake snake = GameObject.FindObjectOfType<Snake>();
        snake.IsTesting = true;                  // Make game not pause on collision
        snake.direction = Vector2.right;

        // Wait for the snake to collide with the wall
        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(snake.IsGamePaused);

    }
}
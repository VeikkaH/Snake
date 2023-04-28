using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class SnakeGameTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator ScoreIncreasesOnEat()
    {

        Snake snake = GameObject.FindObjectOfType<Snake>();
        Food food = GameObject.FindObjectOfType<Food>();
        //var snake = new GameObject().AddComponent<Snake>();
        //var food = new GameObject().AddComponent<Food>();

        snake.IsTesting = true;

        Score scoreController = GameObject.FindObjectOfType<Score>();

        int initialScore = scoreController.score;

        snake.transform.position = Vector2.zero;
        food.transform.position = new Vector2(1, 0);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(initialScore + 1, scoreController.score);
    }
}
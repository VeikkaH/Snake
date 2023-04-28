using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FoodTests
{
    [UnityTest]
    public IEnumerator FoodRespawnsWhenEaten()
    {
        var snake = new GameObject().AddComponent<Snake>();
        var food = new GameObject().AddComponent<Food>();

        // Place the snake and food close together
        snake.transform.position = Vector2.zero;
        food.transform.position = new Vector2(1, 0);

        yield return new WaitForSeconds(0.1f);

        // Check that the food has respawned
        Assert.AreNotEqual(food.transform.position, new Vector2(1, 0));
    }

    [UnityTest]
    public IEnumerator FoodSpawnsCorrectly()
    {
        // Create food
        var food = new GameObject().AddComponent<Food>();

        yield return new WaitForSeconds(0.1f);

        // Check that the food is within the valid range
        Assert.GreaterOrEqual(food.transform.position.x, -6);
        Assert.LessOrEqual(food.transform.position.x, 6);
        Assert.GreaterOrEqual(food.transform.position.y, -6);
        Assert.LessOrEqual(food.transform.position.y, 6);
    }

    [UnityTest]
    public IEnumerator SnakeGrowsOnEatingFood()
    {
        // Create Snake and Food
        var snakeObj = new GameObject();
        var snake = snakeObj.AddComponent<Snake>();
        var foodObj = new GameObject();
        var food = foodObj.AddComponent<Food>();

        // Add Collider
        snakeObj.AddComponent<BoxCollider2D>();
        foodObj.AddComponent<BoxCollider2D>();

        snake.transform.position = Vector2.zero;
        food.transform.position = new Vector2(0, 1);

        snake.IsTesting = true;

        int initialSegmentCount = snake.segments.Count;

        food.OnTriggerEnter2D(snake.GetComponent<Collider2D>());
        snake.OnTriggerEnter2D(food.GetComponent<Collider2D>());

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(initialSegmentCount + 1, snake.segments.Count);
    }
}
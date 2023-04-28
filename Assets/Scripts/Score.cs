using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        scoreText.text = "" + score;
    }
}

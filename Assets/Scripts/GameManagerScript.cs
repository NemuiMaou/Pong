using System;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Ball ball;
    public float leftScore;
    public float rightScore;

    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    public void LeftScores()
    {
        leftScore++;
        Debug.Log($"Left player scored! {leftScore}:{rightScore}");
    }

    public void RightScores()
    {
        
        rightScore++;
        Debug.Log($"Right player scored! {leftScore}:{rightScore}");
    }
    public void BallReset(bool value)
    {
        ball.NextPosition(value);
    }

    public void EndGame(string winner)
    {
        if (winner.Equals("Left"))
        {
            Debug.Log($"Game Over, Left Paddle Wins! {leftScore}:{rightScore}");
        }
        else
        {
            Debug.Log($"Game Over, Right Paddle Wins! {leftScore}:{rightScore}");
        }

        leftScore = 0;
        rightScore = 0;
    }
}

using System;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Ball ball;
    public float leftScore;
    public float rightScore;
    public Transform camera;
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    

    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }
    public void LeftScores()
    {
        leftScore++;
        leftScoreText.text = $"{leftScore}";
        

        Debug.Log($"Left player scored! {leftScore}:{rightScore}");
    }

    public void RightScores()
    {
        
        rightScore++;
        rightScoreText.text = $"{rightScore}";
        

        Debug.Log($"Right player scored! {leftScore}:{rightScore}");
    }

    public void CameraEvent()
    {
        leftScoreText.color = Color.blue;
        rightScoreText.color = Color.red;
        
        Vector3 temp = leftScoreText.transform.position;
        leftScoreText.transform.position = rightScoreText.transform.position;
        rightScoreText.transform.position = temp;
        
        camera.Rotate(0, 0, 180 );
    }

    public void PaddleIncrease(string paddle)
    {
        GameObject paddleObject = GameObject.FindWithTag(paddle);
        paddleObject.transform.localScale = new Vector3(.25f,.25f,1.75f);
        if (paddleObject.CompareTag("LeftPlayer"))
        {
            leftPaddle.maxTravelHeight = 1.8f;
            leftPaddle.minTravelHeight = -1.8f;
        }else if (paddleObject.CompareTag("RightPlayer"))
        {
            rightPaddle.maxTravelHeight = 1.8f;
            rightPaddle.minTravelHeight = -1.8f;
        }
    }

    public void PaddleNormal()
    {
        leftPaddle.transform.localScale = new Vector3(.25f,.25f,1.25f);
        rightPaddle.transform.localScale = new Vector3(.25f,.25f,1.25f);
        
        leftPaddle.maxTravelHeight = 2.07f;
        leftPaddle.minTravelHeight = -2.07f;
        rightPaddle.maxTravelHeight = 2.07f;
        rightPaddle.minTravelHeight = -2.07f;
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
        leftScoreText.text = $"{leftScore}";
        rightScoreText.text = $"{rightScore}";
        PaddleNormal();
        CameraEvent();
        leftScoreText.color = Color.white;
        rightScoreText.color = Color.white;
    }
}

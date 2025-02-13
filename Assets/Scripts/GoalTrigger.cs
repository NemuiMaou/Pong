using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameManagerScript Script;
    private bool rotate;
    private bool advantage = true;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"made contact with {other.gameObject.name}");
        if (other.CompareTag("Ball"))
        {
            if (tag.Equals("LeftTrigger"))
            {
                Script.RightScores();
                Script.BallReset(false);
            }
            else
            {
                Script.LeftScores();
                Script.BallReset(true);
            }

            if (advantage && Script.rightScore - Script.leftScore == 3)
            {
                Debug.Log("LeftIncrease");
                Script.PaddleNormal();
                Script.PaddleIncrease("LeftPlayer");
                advantage = false;
            }else if (advantage && Script.leftScore - Script.rightScore == 3)
            {
                Debug.Log("RightIncrease");
                Script.PaddleNormal();
                Script.PaddleIncrease("RightPlayer");
                advantage = false;
            }
            
            if (!rotate && (Script.leftScore == 8 || Script.rightScore == 8))
            {
                Debug.Log("Camera Event");
                Script.CameraEvent();
                rotate = true;
                
            }

            if (Script.leftScore >= 11 || Script.rightScore >= 11)
            {
                if (Script.leftScore >= 11)
                {
                    Script.EndGame("Left");
                }
                else
                {
                    Script.EndGame("Right");
                }
            }
        }
    }
}

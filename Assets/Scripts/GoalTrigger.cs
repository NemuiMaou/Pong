using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameManagerScript Script;

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

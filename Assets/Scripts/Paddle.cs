using UnityEngine;



public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;



    private float movement;
    
    void FixedUpdate()
    {
        if (player.CompareTag("LeftPlayer"))
        {
            float movementAxis = Input.GetAxis("LeftPaddle");

            Transform paddleTransform = GetComponent<Transform>();
            paddleTransform.position += new Vector3(movementAxis * speed * Time.deltaTime, 0f, 0f);
        }

        if (player.CompareTag("RightPlayer"))
        {
            float movementAxis = Input.GetAxis("RightPaddle");

            Transform paddleTransform = GetComponent<Transform>();
            paddleTransform.position += new Vector3(movementAxis * speed * Time.deltaTime, 0f, 0f);
        }
    }
}

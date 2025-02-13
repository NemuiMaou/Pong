using System;
using UnityEngine;



public class Paddle : MonoBehaviour
{
    public float maxTravelHeight;
    public float minTravelHeight;
    public float speed;
    public float collisionBallSpeedUp = 1.5f;
    public string inputAxis;
    public AudioClip pongSound;
    private AudioSource audioSrc;

    // Update is called once per frame
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        float direction = Input.GetAxis(inputAxis);
        Vector3 newPosition = transform.position + new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minTravelHeight, maxTravelHeight);

        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("hit");
        audioSrc.clip = pongSound;
        
        

        var paddleBounds = GetComponent<BoxCollider>().bounds;
        float maxPaddleHeight = paddleBounds.max.x;
        float minPaddleHeight = paddleBounds.min.x;

        // Get the percentage height of where it hit the paddle (0 to 1) and then remap to -1 to 1 so we have symmetry
        float pctHeight = (other.transform.position.x - minPaddleHeight) / (maxPaddleHeight - minPaddleHeight);
        float bounceDirection = (pctHeight - 0.5f) / 0.5f;
        // Debug.Log($"pct {pctHeight} + bounceDir {bounceDirection}");

        // flip the velocity and rotation direction
        Vector3 currentVelocity = other.relativeVelocity;
        float newSign = currentVelocity.z > 0 ? -1f: 1f;
        float newRotSign = newSign < 0f ? 1f: -1f;

        // Change the velocity between -60 to 60 degrees based on where it hit the paddle
        float newSpeed = currentVelocity.magnitude * collisionBallSpeedUp;
        Vector3 newVelocity = new Vector3(0f, 0f, newSign) * newSpeed;
        newVelocity = Quaternion.Euler(0f, newRotSign * -60f * bounceDirection, 0f) * newVelocity;
        other.rigidbody.linearVelocity = newVelocity;

        float pitchIncrease = newSpeed * .05f;
        audioSrc.pitch = .85f + pitchIncrease;
        audioSrc.Play();
        
        // Debug.DrawRay(Vector3.zero, Vector3.right, Color.red);
        // Debug.DrawRay(Vector3.zero, Quaternion.Euler(0f, 30f, 0f) * Vector3.right, Color.yellow);
        // Debug.Break();
        
        // Debug.Log("newSpeed: " + newSpeed);
        // Debug.Log("cur vel " + currentVelocity);
        // Debug.Log("new vel " + newVelocity);
    }
}
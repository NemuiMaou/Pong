using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 150.0f;
    private Rigidbody rb;
    private float speedIncrease = 1.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AddStartingForce();
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log($"made contact with {other.gameObject.name}");

        if (other.gameObject.CompareTag("LeftPlayer") || other.gameObject.CompareTag("RightPlayer"))
        {
            float speed = other.relativeVelocity.magnitude;
            float newSpeed = speed * speedIncrease;

            Vector3 newVelocity = other.relativeVelocity;
            newVelocity = newVelocity.normalized * newSpeed;

            rb.linearVelocity = newVelocity;
        }
    }

    private void AddStartingForce()
    {
        rb.position = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector3 direction = new Vector3(x, 0f, z);
        rb.AddForce(direction * speed);
    }
    
    public void NextPosition(bool trigger)
    {
        rb.position = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        
        if (!trigger)
        {
            float x = Random.value < 0.5f ? -1.0f : 1.0f;
            float z = Random.value < 0.5f ? 0.5f : 1.0f;

            Vector3 direction = new Vector3(x, 0f, z);
            rb.AddForce(direction * speed);
        }
        else
        {
            float x = Random.value < 0.5f ? -1.0f : 1.0f;
            float z = Random.value < 0.5f ? -1.0f : -0.5f;

            Vector3 direction = new Vector3(x, 0f, z);
            rb.AddForce(direction * speed);
        }
    }
}
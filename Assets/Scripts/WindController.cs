using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public Rigidbody2D carRb;
    public ParticleSystem windEffect;
    
    public float windSpeed = 250f; // The speed of the wind force
    public float rotationSpeed = 50f; // Degrees per second
    public bool isClockwise = true; // Set this to false if you want counterclockwise

    private float _currentAngle = 180f; // Angle in degrees
    private Vector2 _windDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        _windDirection = -transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
        // Update the wind angle based on time and rotation speed
        _currentAngle += (isClockwise ? 1 : -1) * rotationSpeed * Time.deltaTime;

        // Keep angle between 0 and 360
        _currentAngle = Mathf.Repeat(_currentAngle, 360f);

        // Calculate the wind direction from the angle (for 2D, X and Y axes)
        float radians = _currentAngle * Mathf.Deg2Rad;
        _windDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

        // Rotate the particles
        windEffect.transform.forward = _windDirection;
        
        // Apply wind force to objects
        ApplyWindForce();
    }

    void ApplyWindForce()
    {
        carRb.AddForce(_windDirection * (windSpeed * Time.deltaTime));
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) isClockwise = !isClockwise;
    }
    
    public Vector2 GetWindDirection()
    {
        return _windDirection;
    }
    
    // This method draws the wind direction as a gizmo in the Scene view
    private void OnDrawGizmos()
    {
        // Draw a circle (as the center point) to visualize the wind origin
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1);

        // Draw a line representing the wind direction
        Gizmos.color = Color.red;
        Vector3 windEndPoint = new Vector3(_windDirection.x, _windDirection.y, 0) * 1;
        Gizmos.DrawLine(transform.position, transform.position + windEndPoint);
        
        // Draw a line representing the car direction
        Gizmos.color = Color.cyan;
        Vector3 carEndPoint = new Vector3(carRb.transform.right.x, carRb.transform.right.y, 0) * 1;
        Gizmos.DrawLine(transform.position, transform.position + carEndPoint);
    }
}

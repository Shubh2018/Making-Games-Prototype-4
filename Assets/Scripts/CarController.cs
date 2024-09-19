using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [HideInInspector] public WindController windController;
    public float lerpValue = 0.05f;
    
    // Start is called before the first frame update
    void Awake()
    {
        windController = FindObjectOfType<WindController>();
        windController.CarRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust car's orientation
        var windDir = windController.GetWindDirection();
        transform.right = Vector2.Lerp(transform.right, windDir, lerpValue);
     }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + transform.right, 0.2f);
    }
}

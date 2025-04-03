using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_sac : MonoBehaviour
{
    private bool HasLaunched = false;
    private Vector3 startPosition; 
    public Rigidbody Body;
    public float bat_force = 10;
    public float bag_mass = 10;
    public float timing = 0.5f; // Value between 0.0 and 1.0 

    void Start() {
        Body = GetComponent<Rigidbody>();
        Body.mass = bag_mass;
        startPosition = transform.position;
    }

    void Update() {
        if (!HasLaunched && Input.GetKeyDown(KeyCode.Space)) {
            HasLaunched = true;
            float adjustedForce = bat_force * bag_mass * timing; 
            Body.AddForce(new Vector3(adjustedForce, adjustedForce, 0), ForceMode.Impulse);
            Body.angularVelocity = new Vector3(0, 0, -adjustedForce);
        }
    }
}

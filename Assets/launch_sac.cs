using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_sac : MonoBehaviour
{
    public Rigidbody Body;
    public float force = 10;
    public float mass = 10;
    public float timing = 0.5f; // Value between 0.0 and 1.0 
    private bool Has_launched = false;

    // Start is called before the first frame update
    void Start() {
        // Get the Rigidbody component of the current GameObject
        Body = GetComponent<Rigidbody>();
        Body.mass = mass;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && Has_launched == false) {
            float adjustedForce = force * mass * timing; // Calculate force based on mass and timing
            Body.AddForce(new Vector3(adjustedForce, adjustedForce, 0), ForceMode.Impulse);
            Body.angularVelocity = new Vector3(0, 0, -adjustedForce);
            Has_launched = true;
        }
    }
}

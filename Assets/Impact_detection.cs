using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Impact_detection : MonoBehaviour
{
    public float minForceThreshold = 5f; // Minimum force required to trigger

    

    // private GameObject otherObject;
    
    public follow_camera FollowCameraScript; // Drag the GameObject with ScriptB in Inspector


    // Find by name
    void Start() {
        GameObject otherObject = GameObject.Find("Main Camera");
        if (otherObject != null) {
            FollowCameraScript = otherObject.GetComponent<follow_camera>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the impact force
        float impactForce = (collision.impulse.magnitude / Time.fixedDeltaTime) / 1000.0f;

        if (impactForce >= minForceThreshold)
        {
            HandleImpact(collision, impactForce);
        }
    }

    void HandleImpact(Collision collision, float force)
    {
        // Debug.Log($"Hit {collision.gameObject.name} with force: {force}");
        // Your custom logic here

        if (FollowCameraScript != null) {
            FollowCameraScript.StartCoroutine(FollowCameraScript.HitCamera(0.35f, new Vector3(force/5.0f, (force / 10.0f) * Random.Range(-1f, 1f), (force / 5.0f) * Random.Range(-1f, 1f)), 4.0f));
        }
    }
}
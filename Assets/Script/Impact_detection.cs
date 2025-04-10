using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Impact_detection : MonoBehaviour
{
    public float minForceThreshold = 5f; // Minimum force required to trigger

    

    // private GameObject otherObject;
    
    public follow_camera FollowCameraScript; // Drag the GameObject with ScriptB in Inspector

    public TimeManager slowmotionScript;

    public Rigidbody Body;

    public GameObject HitGroundEffectPrefab; // assigned in edit mode

    // Find by name
    void Start() {
        GameObject otherObject = GameObject.Find("Main Camera");
        if (otherObject != null) {
            FollowCameraScript = otherObject.GetComponent<follow_camera>();
        }
    }

    void OnCollisionEnter(Collision collision) {
        

        // Calculate the impact force
        float impactForce = (collision.impulse.magnitude / Time.fixedDeltaTime) / 1000.0f;
        
        if (impactForce >= minForceThreshold) {
            GameObject HitGroundEffectPrefabInstance = Instantiate(HitGroundEffectPrefab);
            HitGroundEffectPrefabInstance.transform.position = transform.position;
            // HitGroundEffectPrefabInstance.transform.position = collision.transform.position;
            HandleImpact(collision, Mathf.Clamp(impactForce, -75.0f, 75.0f));
        }
    }

    void HandleImpact(Collision collision, float force)
    {

        // Your custom logic here
        Debug.Log($"Hit {collision.gameObject.name} with force: {force} velocity: {Body.velocity.magnitude}");

        if (FollowCameraScript != null && FollowCameraScript.Is_shaking == false) {
            FollowCameraScript.StartCoroutine(FollowCameraScript.HitCamera(0.35f, new Vector3(force/5.0f, (force / 10.0f) * Random.Range(-1f, 1f), (force / 5.0f) * Random.Range(-1f, 1f)), 4.0f));
            if (force > 60.0f || Body.velocity.magnitude > 50.0f)
            {
                slowmotionScript.DoSlowMotion();
            }
        }
    }
}
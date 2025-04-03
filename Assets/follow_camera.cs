using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class follow_camera : MonoBehaviour {
    public Transform Target_Transform;

    public Vector3 BaseOffset = new Vector3(2.0f, 2.0f, -8.0f);

    private bool Has_launched = false;
    //private IEnumerator Shake(float duration, float magnitude, float frequency = 15f, float returnThreshold = 0.1f)
    //{
    //    Quaternion originalRotation = transform.rotation;
    //    float current_time = 0.0f;

    //    // For smooth interpolation
    //    float shakeTimer = 0f;
    //    Vector3 previousShake = Vector3.zero;
    //    Vector3 currentShake = Vector3.zero;

    //    while (current_time < duration)
    //    {
    //        // Update shake position at specified frequency
    //        if (shakeTimer <= 0f)
    //        {
    //            previousShake = currentShake;
    //            currentShake = new Vector3(
    //                Random.Range(-1f, 1f) * magnitude,
    //                Random.Range(-1f, 1f) * magnitude,
    //                0f);
    //            shakeTimer = 1f / frequency;
    //        }

    //        // Calculate progress (0-1) through current shake segment
    //        float lerpFactor = 1f - (shakeTimer * frequency);
    //        Vector3 smoothedShake = Vector3.Lerp(previousShake, currentShake, lerpFactor);

    //        // Apply rotation using Quaternion.Euler for proper rotation
    //        transform.rotation = originalRotation * Quaternion.Euler(smoothedShake);

    //        shakeTimer -= Time.deltaTime;
    //        current_time += Time.deltaTime;

    //        yield return null;
    //    }

    //    // Smoothly return to original rotation
    //    while (Quaternion.Angle(transform.rotation, originalRotation) > returnThreshold)
    //    {
    //        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * frequency);
    //        yield return null;
    //    }

    //    // Ensure exact final rotation
    //    transform.rotation = originalRotation;
    //}

    public IEnumerator HitCamera(float duration, Vector3 direction, float returnThreshold = 0.1f) {
        Quaternion originalRotation = transform.rotation;
        float currentTime = 0f;

        // Shake phase - using sine-out easing for smooth decay
        while (currentTime < duration) {
            float progress = currentTime / duration;
            float sineOutProgress = Mathf.SmoothStep(0f, 1f, progress);
            float decay = 1f - sineOutProgress;

            // Apply shake with decay
            Vector3 shakeOffset = direction * decay;
            transform.rotation = originalRotation * Quaternion.Euler(shakeOffset);

            currentTime += Time.deltaTime;
            yield return null;
        }

        // Return phase - using sine-out easing for smooth return
        float returnTime = 0f;
        float returnDuration = duration * 0.5f;
        Quaternion startReturnRotation = transform.rotation;

        while (returnTime < returnDuration) {
            returnTime += Time.deltaTime;
            float returnProgress = Mathf.SmoothStep(0f, 1f, returnTime / returnDuration);

            transform.rotation = Quaternion.Slerp(startReturnRotation, originalRotation, returnProgress);
            yield return null;
        }

        // Final snap to original rotation
        transform.rotation = originalRotation;
    }
    // Start is called before the first frame update
    void Start() {
        if (Target_Transform == null) {
            Debug.LogError("Target_Transform is not assigned.");
        }
    }

    // Update is called once per frame
    void Update() {
        // Make the camera follow the target position
        if (Input.GetKeyDown(KeyCode.Space) && Has_launched == false) {
            //StartCoroutine(Shake(0.4f, 5.0f, 4.0f));
            StartCoroutine(HitCamera(0.75f, new Vector3(-5.0f, 5.0f, -2.207f), 4.0f));
            Has_launched = true;
        }

        if (Target_Transform != null) {
            transform.position = new Vector3(Target_Transform.position.x + BaseOffset.x, Target_Transform.position.y + BaseOffset.y, Target_Transform.position.z + BaseOffset.z);
        }
    }
}

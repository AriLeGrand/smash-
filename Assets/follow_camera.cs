using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class follow_camera : MonoBehaviour {
    public Transform Target_Transform;

    public Vector3 BaseOffset = new Vector3(2.0f, 2.0f, -8.0f);

    private IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPosition = transform.position;

        float current_time = 0.0f;

        while (current_time < duration) {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(Target_Transform.position.x + BaseOffset.x + offsetX, Target_Transform.position.y + BaseOffset.y + offsetY, Target_Transform.position.z + BaseOffset.z);

            float rotationOffsetZ = Random.Range(-1f, 1f) * magnitude;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotationOffsetZ);

            

            current_time += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Shake(0.4f, 0.2f));
        }
        if (Target_Transform != null) {
            transform.position = new Vector3(Target_Transform.position.x + BaseOffset.x, Target_Transform.position.y + BaseOffset.y, Target_Transform.position.z + BaseOffset.z);
        }
    }
}

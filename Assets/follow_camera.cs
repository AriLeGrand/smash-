using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_camera : MonoBehaviour {
    public Transform Target_Transform;

    // Start is called before the first frame update
    void Start() {
        if (Target_Transform == null) {
            Debug.LogError("Target_Transform is not assigned.");
        }
    }

    // Update is called once per frame
    void Update() {
        // Make the camera follow the target position
        if (Target_Transform != null) {
            transform.position = new Vector3(Target_Transform.position.x, Target_Transform.position.y, Target_Transform.position.z - 10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitEffect : MonoBehaviour {
    private float SelfDestroyDelayValue = 2.0f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SelfDestroyDelay());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator SelfDestroyDelay() {
        yield return new WaitForSeconds(SelfDestroyDelayValue);
        Object.Destroy(this.gameObject);
    }
}

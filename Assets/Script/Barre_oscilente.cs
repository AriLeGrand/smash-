using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre_oscilente : MonoBehaviour
{

    private float current_time;
    private bool HasPressedSpace = false;
    public launch_sac launch_sacScript;

    // Start is called before the first frame update
    void Start()
    {
        // launch_sacScript = GetComponent<launch_sac>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !HasPressedSpace)
        {
            HasPressedSpace = true;
        }


        if (!HasPressedSpace)
        {
            transform.position = new Vector3((Mathf.Sin(current_time) * 75.0f) + 85.0f, transform.position.y, transform.position.z);
            current_time += Time.deltaTime;

            launch_sacScript.timing = 1.0f - Mathf.Abs(Mathf.Sin(current_time));
            launch_sacScript.dir = new Vector2((Mathf.Sin(current_time) + 1.0f) / 2.0f, (1.0f - (Mathf.Abs(Mathf.Sin(current_time) + 1.0f)) + 1.0f) / 2.0f);
        }
    }
}

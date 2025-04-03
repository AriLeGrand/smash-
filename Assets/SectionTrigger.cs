using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class SectionTrigger : MonoBehaviour
{

    public GameObject Map_Section;

    public Transform sactransform;

    private bool Has_spawned = false;


    void OnEnable ()    
    {
        sactransform = GameObject.Find("Sac")?.transform;
    }

    void Update ()
    {
        if (sactransform == null)
        {
            return;
        }
        

        if (sactransform.position.x - transform.position.x > -10 && Has_spawned == false)
        {
            Instantiate(Map_Section, transform.position + new Vector3(70, 0, 0), Quaternion.identity);
            Has_spawned = true;
        } else if (Has_spawned == true && sactransform.position.x - transform.position.x > 100) {
            Destroy(gameObject);
        }
    }
}
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
            GameObject newSection = Instantiate(Map_Section, transform.position + new Vector3(30, 0, 0), Quaternion.identity);
            newSection.name = Map_Section.name; // Fix instance name
            Has_spawned = true;
        } else if (Has_spawned == true && sactransform.position.x - transform.position.x > 40) {
            Destroy(gameObject);
        }
    }
}
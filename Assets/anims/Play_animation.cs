using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_animation : MonoBehaviour {
    private bool Has_launched = false;
    public Animator batte_animator;
    public Animator sac_animator;

    public GameObject sac_anim_gameobject;
    public GameObject sac_gameobject;

    public launch_sac sac_script;
    public follow_camera follow_camera_script;
    public ImpactFrameEffect impact_frame_script;

    // Start is called before the first frame update
    void Start() {
        sac_gameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && Has_launched == false) {
            StartCoroutine(Playanim());
        }
    }

    IEnumerator Playanim()
    {
        batte_animator.SetTrigger("Hit");
        sac_animator.SetTrigger("Hit");
        // //Print the time of when the function is first called.
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);



        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(0.64f);
        follow_camera_script.Shake();
        if (sac_script.timing > 0.9) {
            impact_frame_script.StartCoroutine(impact_frame_script.Impact());
        }
        



        yield return new WaitForSeconds(0.66f);

        follow_camera_script.SetHasLaunched(true);
        sac_anim_gameobject.SetActive(false);
        sac_gameobject.SetActive(true);

        sac_script.LaunchSac();

        
        

    }
}

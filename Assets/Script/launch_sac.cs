using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_sac : MonoBehaviour
{
    public Rigidbody Body;
    public float force = 10;
    public float mass = 10;
    public float timing = 0.5f; // Value between 0.0 and 1.0 
    private Vector3 startPosition;
    public Vector2 dir = new Vector2(1.0f, 0.25f);
    private bool Has_launched = false;
    private bool Has_started_moving = false;

    public float velocityThreshold = 0.1f;
    public float angularVelocityThreshold = 0.1f;
    public float Time_to_end_game = 2.0f;
    private float Immobile_time = 0f;

    private bool Game_ended = false;

    // Start is called before the first frame update
    void Start() {
        // Get the Rigidbody component of the current GameObject
        Body = GetComponent<Rigidbody>();
        Body.mass = mass;
        startPosition = transform.position;
    }
    public void LaunchSac() {
        if (Has_launched == false) {
            float adjustedForce = force * mass * timing; // Calculate force based on mass and timing
            Body.AddForce(new Vector3((adjustedForce * dir.x) + 50.0f, (adjustedForce * dir.y) + 30.0f, 0), ForceMode.Impulse);
            Body.angularVelocity = new Vector3(0, 0, -adjustedForce);
            Has_launched = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Has_launched  && !Has_started_moving && Body.velocity.magnitude > velocityThreshold)
        {
            Has_started_moving = true;
        }

        if (Has_started_moving && Is_sac_immobilized())
        {
            Immobile_time += Time.deltaTime;
        }
        else 
        {
            Immobile_time = 0f;
        }

        if (Immobile_time >= Time_to_end_game)
        {
            EndGame();
        }
    }

    bool Is_sac_immobilized()
    {
        return Body.velocity.magnitude < velocityThreshold && Body.angularVelocity.magnitude < angularVelocityThreshold;
    }

    void EndGame()
    {
        if (Game_ended) return;

        Debug.Log("Gold Earned : " + GameManager.Instance.gold);
        Debug.Log("La partie est terminee");

        float distanceTravelled = transform.position.x - startPosition.x;
        int goldGained = Mathf.FloorToInt(distanceTravelled * GameManager.Instance.goldPerUnit);

        GameManager.Instance.AddGold(goldGained);

        GameManager.Instance.CheckAndUpdatePersonnalBest(Mathf.FloorToInt(distanceTravelled));

        Game_ended = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowRetryButton();
        }
        else 
        {
            Debug.LogError("UIManager.Instance est NULL");
        }
    }
}

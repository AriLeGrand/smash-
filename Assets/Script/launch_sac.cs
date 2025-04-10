using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_sac : MonoBehaviour
{
    private bool HasLaunched = false;
    private bool hasStartedMoving = false; 
    private Vector3 startPosition;
    public Rigidbody Body;
    public float timing = 0.5f; // Valeur entre 0.0 et 1.0 

    public float velocityThreshold = 0.1f;
    public float angularVelocityThreshold = 0.1f;
    public float timeToEndGame = 2.0f;  
    private float immobileTime = 0f;

    private bool gameEnded = false;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
        Body.mass = GameManager.Instance.bagMass;
        startPosition = transform.position;
    }

    void Update()
    {
        if (!HasLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            HasLaunched = true;
            float adjustedForce = GameManager.Instance.batForce * GameManager.Instance.bagMass * timing;
            Body.AddForce(new Vector3(adjustedForce, adjustedForce, 0), ForceMode.Impulse);
            Body.angularVelocity = new Vector3(0, 0, -adjustedForce);
        }

        if (HasLaunched && !hasStartedMoving && Body.velocity.magnitude > velocityThreshold)
        {
            hasStartedMoving = true;
        }

        if (hasStartedMoving && IsSacImmobilized())
        {
            immobileTime += Time.deltaTime;
        }
        else
        {
            immobileTime = 0f;
        }

        if (immobileTime >= timeToEndGame)
        {
            EndGame();
        }
    }

    bool IsSacImmobilized()
    {
        return Body.velocity.magnitude < velocityThreshold && Body.angularVelocity.magnitude < angularVelocityThreshold;
    }

    void EndGame()
    {
        if (gameEnded) return;

        Debug.Log("Gold earned : " + GameManager.Instance.gold);
        Debug.Log("La partie est terminée !");

        float distanceTravelled = transform.position.x - startPosition.x;
        int goldGained = Mathf.FloorToInt(distanceTravelled * GameManager.Instance.goldPerUnit);

        GameManager.Instance.AddGold(goldGained);

        GameManager.Instance.CheckAndUpdatePersonnalBest(Mathf.FloorToInt(distanceTravelled));

        gameEnded = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowRetryButton();
        }
        else
        {
            Debug.LogError("UIManager.Instance est NULL !");
        }
    }
}

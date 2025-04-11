using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    
    private float lastPositionX;
    private float spawnOffSet = 6.5f;

    void Start()
    {
        lastPositionX = player.position.x;
    }

    void Update()
    {
        float distanceTravelled = player.position.x - lastPositionX;
        float displayScore = player.position.x - spawnOffSet;

        displayScore = Mathf.Max(0f, displayScore);
        scoreText.text = "Score : " + displayScore.ToString("0");

        GameManager.Instance.CheckAndUpdatePersonnalBest((int)displayScore);

        if (distanceTravelled > 0)
        {
            float goldGained = distanceTravelled * GameManager.Instance.goldPerUnit;
            GameManager.Instance.AddGold((int)goldGained);
        }

        lastPositionX = player.position.x;
    }
}
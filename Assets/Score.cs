using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    public float goldPerUnit = 0.5f;
    private float lastPositionX;

    void Start()
    {
        lastPositionX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTravelled = player.position.x - lastPositionX;
        scoreText.text = "Score : " + player.position.x.ToString("0");

        if (distanceTravelled > 0)
        {
            float goldGained = distanceTravelled * goldPerUnit;
            GameManager.Instance.AddGold((int)goldGained);
        }

        lastPositionX = player.position.x;
    }
}

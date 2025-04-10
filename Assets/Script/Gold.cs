using UnityEngine;
using UnityEngine.UI; 

public class Gold : MonoBehaviour
{
    public Text goldText; 

    void Start()
    {
        if (goldText == null)
        {
            Debug.LogError("goldText n'est pas assigné dans l'inspecteur!");
        }
    }

    void Update()
    {
        if (goldText != null && GameManager.Instance != null)
        {
            goldText.text = "Gold : " + GameManager.Instance.gold.ToString("0");
        }
    }
}
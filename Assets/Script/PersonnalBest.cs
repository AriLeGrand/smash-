using UnityEngine;
using UnityEngine.UI;

public class PersonnalBest : MonoBehaviour
{
    public Text personnalBestText;

    void Start()
    {
        if (personnalBestText == null)
        {
            Debug.LogError("personnalBestText n'est pas assigné dans l'inspecteur !");
        }
    }

    void Update()
    {
        if (personnalBestText != null && GameManager.Instance != null)
        {
            personnalBestText.text = "PB : " + GameManager.Instance.personnalBestScore.ToString("0");
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject retryButton; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        retryButton.SetActive(false); 
    }

    public void ShowRetryButton()
    {
        retryButton.SetActive(true); 
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

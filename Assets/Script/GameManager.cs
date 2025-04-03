using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int gold = 0;
    public float goldPerUnit = 0.5f;

    public float batForce = 10f;
    public float bagMass = 10f;

    public int upgradeBatForceCost = 20;
    public int upgradeBagMassCost = 15;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            LoadGold(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        SaveGold(); 
        Debug.Log("Gold: " + gold);
    }

    public bool TrySpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            SaveGold(); 
            return true;
        }
        return false;
    }

    void SaveGold()
    {
        PlayerPrefs.SetInt("PlayerGold", gold);
        PlayerPrefs.Save();
    }

    void LoadGold()
    {
        gold = PlayerPrefs.GetInt("PlayerGold", 0); 
    }

    public void ResetGold()
    {
        gold = 0;
        SaveGold();
    }
}

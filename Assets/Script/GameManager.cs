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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }

    public bool TrySpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            return true; 
        }
        return false; 
    }
}

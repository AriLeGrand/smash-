using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int gold = 0;
    public float goldPerUnit = 0.5f;

    public float batForce = 10;
    public float bagMass = 10;


    public float ratio = 1.5f; 
    public int upgradeBatForceCost = 20;
    public int upgradeBagMassCost = 15;
    public int upgradeGoldPerUnitCost = 100;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        SaveData();
        Debug.Log("Gold: " + gold);
    }

    public bool TrySpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            SaveData();
            return true;
        }
        return false;
    }

    public void ResetGold()
    {
        gold = 0;
        SaveData();
    }


    public void UpgradeBatForce()
    {
        if (TrySpendGold(upgradeBatForceCost))
        {
            batForce += 1; 
            upgradeBatForceCost = Mathf.RoundToInt(upgradeBatForceCost * ratio);

        }
    }

    public void UpgradeBagMass()
    {
        if (TrySpendGold(upgradeBagMassCost))
        {
            bagMass += 1;
            upgradeBagMassCost = Mathf.RoundToInt(upgradeBagMassCost * ratio);
        }
    }

    public void UpgradeGoldPerUnit()
    {
        if (TrySpendGold(upgradeGoldPerUnitCost))
        {
            goldPerUnit *= ratio;
            upgradeGoldPerUnitCost = Mathf.RoundToInt(upgradeGoldPerUnitCost * ratio);
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("PlayerGold", gold);
        PlayerPrefs.SetFloat("BatForce", batForce);
        PlayerPrefs.SetFloat("BagMass", bagMass);
        PlayerPrefs.SetInt("UpgradeBatForceCost", upgradeBatForceCost);
        PlayerPrefs.SetInt("UpgradeBagMassCost", upgradeBagMassCost);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        gold = PlayerPrefs.GetInt("PlayerGold", 0);
        batForce = PlayerPrefs.GetFloat("BatForce", 10f);
        bagMass = PlayerPrefs.GetFloat("BagMass", 10f);
        upgradeBatForceCost = PlayerPrefs.GetInt("UpgradeBatForceCost", 20);
        upgradeBagMassCost = PlayerPrefs.GetInt("UpgradeBagMassCost", 15);
    }

    public void ResetData()
    {
        gold = 0;
        batForce = 10f;
        bagMass = 10f;
        upgradeBatForceCost = 20;
        upgradeBagMassCost = 15;
        SaveData();
    }
}

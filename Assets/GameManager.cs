using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int gold = 0;

    void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold: " + gold);
    }
}

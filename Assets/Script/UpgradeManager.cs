using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text batForceButtonText;
    public Text bagMassButtonText;

    public Button batForceButton;
    public Button bagMassButton;

    public float batForceIncrease = 2f;
    public float bagMassReduction = 1f;

    void Start()
    {
        UpdateUI();
    }

    public void UpgradeBatForce()
    {
        if (GameManager.Instance.TrySpendGold(GameManager.Instance.upgradeBatForceCost))
        {
            GameManager.Instance.batForce += batForceIncrease;
            GameManager.Instance.upgradeBatForceCost += 10;
            UpdateUI();
        }
    }

    public void UpgradeBagMass()
    {
        if (GameManager.Instance.TrySpendGold(GameManager.Instance.upgradeBagMassCost))
        {
            GameManager.Instance.bagMass -= bagMassReduction;
            GameManager.Instance.upgradeBagMassCost += 8;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        batForceButtonText.text = "Améliorer Batte (" + GameManager.Instance.upgradeBatForceCost + " Gold)";
        bagMassButtonText.text = "Réduire Masse (" + GameManager.Instance.upgradeBagMassCost + " Gold)";

        batForceButton.interactable = GameManager.Instance.gold >= GameManager.Instance.upgradeBatForceCost;
        bagMassButton.interactable = GameManager.Instance.gold >= GameManager.Instance.upgradeBagMassCost;
    }

    void Update()
    {
        UpdateUI();
    }
}

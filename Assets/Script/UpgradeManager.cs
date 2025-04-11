using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text batForceButtonText;
    public Text bagMassButtonText;
    public Text goldUpgradeButtonText;

    public Button batForceButton;
    public Button bagMassButton;
    public Button goldUpgradeButton;

    void Start()
    {
        // Lier les boutons dynamiquement
        if (batForceButton != null)
            batForceButton.onClick.AddListener(UpgradeBatForce);

        if (bagMassButton != null)
            bagMassButton.onClick.AddListener(UpgradeBagMass);

        if (goldUpgradeButton != null)
            goldUpgradeButton.onClick.AddListener(UpgradeGoldPerUnit);

        UpdateUI();
    }

    public void UpgradeBatForce()
    {
        GameManager.Instance.UpgradeBatForce();
        UpdateUI();
    }

    public void UpgradeBagMass()
    {
        GameManager.Instance.UpgradeBagMass();
        UpdateUI();
    }

    public void UpgradeGoldPerUnit()
    {
        GameManager.Instance.UpgradeGoldPerUnit();
        UpdateUI();
    }

    void UpdateUI()
    {
        batForceButtonText.text = "Upgrade Bat : " + GameManager.Instance.upgradeBatForceCost + " Gold";
        bagMassButtonText.text = "Upgrade Bag : " + GameManager.Instance.upgradeBagMassCost + " Gold";
        goldUpgradeButtonText.text = "Upgrade Gold Earned : " + GameManager.Instance.upgradeGoldPerUnitCost + " Gold";

        batForceButton.interactable = GameManager.Instance.gold >= GameManager.Instance.upgradeBatForceCost;
        bagMassButton.interactable = GameManager.Instance.gold >= GameManager.Instance.upgradeBagMassCost;
        goldUpgradeButton.interactable = GameManager.Instance.gold >= GameManager.Instance.upgradeGoldPerUnitCost;
    }

    void Update()
    {
        UpdateUI();
    }
}

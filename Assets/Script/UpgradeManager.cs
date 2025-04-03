using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Text batForceButtonText;
    public Text bagMassButtonText;

    public Button batForceButton;
    public Button bagMassButton;

    void Start()
    {
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

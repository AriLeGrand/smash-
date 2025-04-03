using UnityEngine;
using UnityEngine.UI; // Assurez-vous d'importer ce namespace pour utiliser Text

public class Gold : MonoBehaviour
{
    public Text goldText; // Référence à votre objet Text dans l'UI

    void Start()
    {
        // Vérifiez si la référence à goldText est null
        if (goldText == null)
        {
            Debug.LogError("goldText n'est pas assigné dans l'inspecteur!");
        }
    }

    void Update()
    {
        // Vérifiez si goldText est bien assigné avant de mettre à jour l'affichage
        if (goldText != null && GameManager.Instance != null)
        {
            // Mettez à jour le texte avec le montant d'or actuel du GameManager
            goldText.text = "Gold : " + GameManager.Instance.gold.ToString();
        }
    }
}

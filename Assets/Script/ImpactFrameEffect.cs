using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ImpactFrameEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _impact;

    [SerializeField] private Material _material;

    [SerializeField] private ScriptableRendererFeature _outline;

    [SerializeField] private Material _materiaOutlinel;

    [SerializeField] private ScriptableRendererFeature _invertimpact;

    [SerializeField] private Material _materiaInvertimpact;

    [SerializeField] private TimeManager _timeManager;

    private int _active = Shader.PropertyToID("_Active");

    private void Start()
    {
        _outline.SetActive(false);
        _impact.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Impact());
        }
    }

    private IEnumerator Impact()
    {
        // 1. Activer l'outline
        _outline.SetActive(true);
        _materiaOutlinel.SetFloat(_active, 1f);  // Activer l'outline avec alpha à 1 (pleinement visible)

        // Attendre un moment avant d'activer l'impact
        yield return new WaitForSeconds(0.01f); // Vous pouvez ajuster le délai ici

        // 2. Activer l'impact
        _impact.SetActive(true);
        _material.SetFloat(_active, 1f);  // Activer l'impact avec alpha à 1 (pleinement visible)

        // Appliquer le ralentissement (slow motion)
        _timeManager.DoSlowMotion();

        // Attendre avant de désactiver l'outline
        yield return new WaitForSeconds(0.01f); // Vous pouvez ajuster le délai ici

        // 3. Désactiver l'outline
        _outline.SetActive(false);
        _materiaOutlinel.SetFloat(_active, 0f);  // Désactiver l'outline (alpha à 0)

        // Attendre un peu avant d'activer l'invert impact
        yield return new WaitForSeconds(0.01f); // Ajuster le délai pour l'effet désiré

        // 4. Activer l'invert impact
        _invertimpact.SetActive(true);
        _materiaInvertimpact.SetFloat(_active, 1f);  // Activer l'inversion de l'impact (alpha à 1)

        // Attendre un moment avant de désactiver tous les effets
        yield return new WaitForSeconds(0.01f); // Ajuster le délai pour l'effet désiré

        // 5. Désactiver tous les effets
        _outline.SetActive(false);
        _impact.SetActive(false);
        _invertimpact.SetActive(false);

        // Réinitialiser les valeurs des shaders
        _materiaOutlinel.SetFloat(_active, 0f);  // Réinitialiser le contour
        _material.SetFloat(_active, 0f);  // Réinitialiser l'impact
        _materiaInvertimpact.SetFloat(_active, 0f);  // Réinitialiser l'inversion

        // Désactiver le ralentissement (slow motion)
    }


}

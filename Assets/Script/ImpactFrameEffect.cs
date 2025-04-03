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

    private int _active = Shader.PropertyToID("_Active");

    // Start is called before the first frame update
    private void Start()
    {
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
        _impact.SetActive(true);
        _material.SetFloat(_active, 1f);
        yield return null;

    }
}

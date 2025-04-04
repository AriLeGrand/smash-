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

    [SerializeField] private TimeManager _timeManager;

    private int _active = Shader.PropertyToID("_Active");

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
        _timeManager.DoSlowMotion();
        yield return null;

    }
}

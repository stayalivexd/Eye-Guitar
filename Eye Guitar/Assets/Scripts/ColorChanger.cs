using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color _enabledColor = Color.red;
    [SerializeField] private Color _disabledColor = Color.white;

    private Renderer _renderer;
    private Color _originalColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogError("Renderer component not found on object: " + gameObject.name);
            enabled = false; // Disable the script if Renderer is missing
            return;
        }

        _originalColor = _renderer.material.color;

        Reset();
    }

    public void Enable()
    {
        if (_renderer == null)
        {
            Debug.LogError("Renderer component is null. Enable() cannot be executed.");
            return;
        }

        _renderer.material.color = _enabledColor;
    }

    public void Reset()
    {
        if (_renderer == null)
        {
            Debug.LogError("Renderer component is null. Reset() cannot be executed.");
            return;
        }

        _renderer.material.color = _disabledColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script yang di assign pada suatu button dan membuat button itu dapat membuka canvas sesuai yg diinginkan di inspector
/// </summary>
[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private CanvasType _desiredCanvasType;

    private CanvasManager _canvasManager;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
        _canvasManager = CanvasManager.GetInstance();
    }

    private void OnButtonClicked()
    {
        _canvasManager.SwitchCanvas(_desiredCanvasType);
    }
}

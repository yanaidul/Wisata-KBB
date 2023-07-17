using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

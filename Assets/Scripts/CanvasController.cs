using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private CanvasType _canvasType;

    #region Properties
    public CanvasType CanvasType => _canvasType;
    #endregion
}

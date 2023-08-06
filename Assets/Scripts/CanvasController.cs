using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script yang diberikan pada canvas agar game scene berpindah ke canvas ini setelah di klik sesuai dengan CanvasTypenya
/// </summary>
public class CanvasController : MonoBehaviour
{
    [SerializeField] private CanvasType _canvasType;

    #region Properties
    public CanvasType CanvasType => _canvasType;
    #endregion
}

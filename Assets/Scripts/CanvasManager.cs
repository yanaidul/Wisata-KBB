using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    Info,
    Mulai,
    Sejarah,
    Wisata,
    Kuis,
    Profil,
    Pengertian,
    WisataAlam,
    WisataBuatan,
    WisataSenbud,
    Login,
    Admin
}

public class CanvasManager : Singleton<CanvasManager>
{
    private List<CanvasController> _canvasControllerList;
    private CanvasController _lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        _canvasControllerList = GetComponentsInChildren<CanvasController>(true).ToList();
        _canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.Login);
    }

    public void SwitchCanvas(CanvasType type)
    {
        if (_lastActiveCanvas != null)
        {
            _lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = _canvasControllerList.Find(x => x.CanvasType == type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            _lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("Desired canvas not found");
        }
    }
}

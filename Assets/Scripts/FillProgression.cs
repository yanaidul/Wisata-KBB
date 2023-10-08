using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class FillProgression : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _percentageText;
    [Header("Gameobject Reference")]
    [SerializeField] private GameObject _nextButton;

    private Slider _slider;
    private PageSwitcher _pageSwitcher;
    private CanvasController _canvasController;
    private int _progress;
    private int _lastProgress;
    private int _totalPages;

    #region Properties
    public int Progress
    {
        get => _progress;

        set
        {
            _progress = value;
        }
    }
    #endregion


    private void Awake()
    {
        if (!TryGetComponent<Slider>(out Slider slider)) return;
        _slider = slider;
        _pageSwitcher = GetComponentInParent<PageSwitcher>();
        _canvasController = GetComponentInParent<CanvasController>();
        if(_pageSwitcher != null) _totalPages = _pageSwitcher.GetPageLength();
    }

    private void Start()
    {
        _lastProgress = 0;
        if (_nextButton == null) return;
        if (!_nextButton.TryGetComponent<Button>(out Button nextButton)) return;
        nextButton.onClick.AddListener(UpdateFillPercentage);
        LoadProgressionToPlayerData();
        UpdateFillPercentage();
    }

    private void UpdateFillPercentage()
    {
        _progress = _pageSwitcher.CurrentPageIndex + 1;
        if (_lastProgress > _progress) return;
        _lastProgress = _progress;
        _slider.value = (_progress * 100) / _totalPages;
        _percentageText.text = $"{_slider.value}%";
        SaveProgressionToPlayerData((int)_slider.value);
    }

    private void SaveProgressionToPlayerData(int progression)
    {
        switch (_canvasController.CanvasType)
        {
            case CanvasType.Sejarah:
                _playerData.SetPlayerSejarahProgression(progression);
                break;
            case CanvasType.Pengertian:
                _playerData.SetPlayerPengertianProgression(progression);
                break;
            case CanvasType.WisataAlam:
                _playerData.SetPlayerWisataAlamProgression(progression);
                break;
            case CanvasType.WisataBuatan:
                _playerData.SetPlayerWisataBuatanProgression(progression);
                break;
            case CanvasType.WisataSenbud:
                _playerData.SetPlayerWisataSenbudProgression(progression);
                break;
        }
    }
    public void LoadProgressionToPlayerData()
    {
        switch (_canvasController.CanvasType)
        {
            case CanvasType.Sejarah:
                _slider.value = _playerData.Data.sejarahProgression;
                _lastProgress = _playerData.Data.sejarahProgression / _totalPages;
                break;
            case CanvasType.Pengertian:
                _slider.value = _playerData.Data.pengertianProgression;
                _lastProgress = _playerData.Data.pengertianProgression / _totalPages;
                break;
            case CanvasType.WisataAlam:
                _slider.value = _playerData.Data.wisataAlamProgression;
                _lastProgress = _playerData.Data.wisataAlamProgression / _totalPages;
                break;
            case CanvasType.WisataBuatan:
                _slider.value = _playerData.Data.wisataBuatanProgression;
                _lastProgress = _playerData.Data.wisataBuatanProgression / _totalPages;
                break;
            case CanvasType.WisataSenbud:
                _slider.value = _playerData.Data.wisataSenbudProgression;
                _lastProgress = _playerData.Data.wisataSenbudProgression / _totalPages;
                break;
        }
        _percentageText.text = $"{_slider.value}%";
    }


}

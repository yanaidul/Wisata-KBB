using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalProgression : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [Header("All Slider References")]
    [SerializeField] private Slider[] _sliders;
    [Header("Text Reference")]
    [SerializeField] private TextMeshProUGUI _percentageText;

    private int _totalProgression;
    private Slider _slider;

    private void OnEnable()
    {
        CalculateTotalProgression();
    }

    private void Awake()
    {
        if (!TryGetComponent<Slider>(out Slider slider)) return;
        _slider = slider;
    }

    private void CalculateTotalProgression()
    {
        _totalProgression = 0;
        _totalProgression += (_playerData.Data.sejarahProgression + _playerData.Data.pengertianProgression +
            _playerData.Data.wisataAlamProgression + _playerData.Data.wisataBuatanProgression +
            _playerData.Data.wisataSenbudProgression);
        _slider.value = (_totalProgression * 100) / (100 * _sliders.Length);
        _percentageText.text = $"{_slider.value}%";
    }
}

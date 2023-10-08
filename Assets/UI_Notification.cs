using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NotificationType
{
    Sejarah,
    Wisata,
    Pengertian,
    WisataAlam,
    WisataBuatan,
    WisataSenbud,
}

public class UI_Notification : MonoBehaviour
{
    [Header("Notification Type")]
    [SerializeField] private NotificationType _notificationType;
    [Header("Sprite")]
    [SerializeField] private Sprite _notComplete;
    [SerializeField] private Sprite _complete;
    [Header("Player Data")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private Image _imageComponent;

    private void Awake()
    {
        if (!TryGetComponent<Image>(out Image image)) return;
        _imageComponent = image;
    }

    private void OnEnable()
    {
        switch (_notificationType)
        {
            case NotificationType.Sejarah:
                if(_playerData.Data.sejarahProgression < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
            case NotificationType.Wisata:
                int totalProgress = _playerData.Data.pengertianProgression + _playerData.Data.wisataAlamProgression +
                    _playerData.Data.wisataBuatanProgression + _playerData.Data.wisataSenbudProgression;
                int _convertToPercentage = (totalProgress * 100) / (100 * 4);

                if (_convertToPercentage < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
            case NotificationType.Pengertian:
                if (_playerData.Data.pengertianProgression < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
            case NotificationType.WisataAlam:
                if (_playerData.Data.wisataAlamProgression < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
            case NotificationType.WisataBuatan:
                if (_playerData.Data.wisataBuatanProgression < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
            case NotificationType.WisataSenbud:
                if (_playerData.Data.wisataSenbudProgression < 100)
                {
                    _imageComponent.sprite = _notComplete;
                }
                else
                {
                    _imageComponent.sprite = _complete;
                }
                break;
        }
    }


}

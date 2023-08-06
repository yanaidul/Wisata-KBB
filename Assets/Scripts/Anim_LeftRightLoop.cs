using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Script animasi kiri-kanan secara loop yang berikan pada suatu game object
/// </summary>
public class Anim_LeftRightLoop : MonoBehaviour
{
    [SerializeField] private float _targetX = 0.3f;
    [SerializeField] private float _duration = 0.3f;

    private Tweener _myTween;

    private void Start()
    {
        if (!TryGetComponent<RectTransform>(out RectTransform rectTransform)) return;
        _myTween = rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + _targetX, _duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
        _myTween.Play();
    }

    private void OnDisable()
    {
        _myTween.Pause();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anim_CharacterJump : MonoBehaviour
{
    [SerializeField] private float _targetY = 0.1f;
    [SerializeField] private float _duration = 0.3f;
    private Tweener _myTween;

    private void Start()
    {
        if (!TryGetComponent<RectTransform>(out RectTransform rectTransform)) return;
        _myTween = rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y+_targetY, _duration).SetEase(Ease.InBounce).SetLoops(-1, LoopType.Yoyo);
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

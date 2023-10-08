using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Anim_Scale : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _duration = 0.3f;
    private Tweener _myTween;

    private Vector3 _initScale = Vector3.zero;
    private RectTransform _rectTransform;

    private void Awake()
    {
        if (!TryGetComponent<RectTransform>(out RectTransform rectTransform)) return;
        _rectTransform = rectTransform;
    }


    private void OnEnable()
    {
        _rectTransform.transform.localScale = _initScale;
        _myTween = _rectTransform.DOScale(_targetScale, _duration).SetEase(Ease.InBounce);
    }

    private void OnDisable()
    {
        _myTween.Kill();
    }


}

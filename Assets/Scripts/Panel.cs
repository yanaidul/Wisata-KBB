using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("Is Panel Already Seen?")]
    [SerializeField] private bool _isSeen = false;

    private void OnEnable()
    {
        _isSeen = true;
    }
}

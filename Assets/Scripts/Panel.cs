using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script yang diberikan pada panel game object untuk memberi tahu ke script lain bila panel ini sedang berada di screen atau tidak
/// </summary>
public class Panel : MonoBehaviour
{
    [Header("Is Panel Already Seen?")]
    [SerializeField] private bool _isSeen = false;

    private void OnEnable()
    {
        _isSeen = true;
    }
}

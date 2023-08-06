using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script scene manager yang fungsinya saat ini hanya diberikan pada exit button agar dapat keluar dari game
/// </summary>
public class SceneManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
}

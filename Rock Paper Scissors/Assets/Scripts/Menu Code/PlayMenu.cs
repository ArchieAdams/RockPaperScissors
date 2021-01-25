﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Basic()
    {
        PlayerPrefs.SetInt("Mode", 0);
    }

    public void Special()
    {
        PlayerPrefs.SetInt("Mode", 1);
    }
}

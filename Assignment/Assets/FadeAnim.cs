using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnim : MonoBehaviour
{
    [SerializeField] private CanvasGroup ui;
    [SerializeField] private AudioSource victorySound;
    public bool fadeIn = false;

    public void showUI()
    {
        fadeIn = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            victorySound.Play();
            if (ui.alpha < 1)
            {
                ui.alpha += Time.deltaTime;
                if (ui.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    public void setStatus(bool status) {
        fadeIn = status;
    }
}

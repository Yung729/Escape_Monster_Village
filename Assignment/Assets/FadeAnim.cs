using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnim : MonoBehaviour
{
    [SerializeField] private CanvasGroup ui;

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

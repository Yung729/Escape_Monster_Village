using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    public void PlayGame() {
        SceneManager.LoadScene(1);

    }

    public void playSound() {
        sound.Play();
    }

    public void QuitGame() {
        Application.Quit();
    }
}

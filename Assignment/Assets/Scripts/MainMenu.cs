using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource sound;

    public void PlayGame() {
        sound.Play();
        SceneManager.LoadScene(1);

    }

    public void playSound() {
        sound.Play();
    }

    public void QuitGame() {
        sound.Play();
        Application.Quit();
    }
}

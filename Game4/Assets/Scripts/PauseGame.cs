using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public GameObject pauseStuff;
    public GameObject sliders;

    public Button resume;
    public Button menu;
    public Slider sliderMusic;
    public Slider sliderSounds;

    public GameObject backgroundMusicSource;
    public GameObject gameSoundsSource;

    private bool isPaused = false;

    void Start()
    {
        pauseStuff.gameObject.SetActive(false);
        sliders.gameObject.SetActive(false);
        sliderMusic.value = 0.5f;
        sliderSounds.value = 0.5f;
        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseStuff.SetActive(true);
                sliders.gameObject.SetActive(true);
                isPaused = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseStuff.SetActive(false);
                sliders.gameObject.SetActive(false);
                isPaused = false;
                Time.timeScale = 1.0f;
            }
        }
        backgroundMusicSource.GetComponent<AudioSource>().volume = sliderMusic.value;
        gameSoundsSource.GetComponent<AudioSource>().volume = sliderSounds.value;
    }

    void Resume()
    {
        pauseStuff.SetActive(false);
        sliders.gameObject.SetActive(true);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}

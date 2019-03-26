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

    private AudioSource backgroundMusicSource;
    private AudioSource gameSoundsSource;
    private AudioSource gameSoundsSource1;

    private bool isPaused = false;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        backgroundMusicSource = manager.backgroundMusicSource;
        gameSoundsSource = manager.gameSoundsSource;
        gameSoundsSource1 = manager.gameSoundsSource1;
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
        backgroundMusicSource.volume = sliderMusic.value;
        gameSoundsSource.volume = sliderSounds.value;
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

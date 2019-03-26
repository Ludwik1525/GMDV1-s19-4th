using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayEventsManager : MonoBehaviour {

    public GameObject pauseStuff;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject sliders;

    public Button resume;
    public Button menu;
    public Button tryAgain;
    public Slider sliderMusic;
    public Slider sliderSounds;

    private AudioSource backgroundMusicSource;
    private AudioSource gameSoundsSource;
    private AudioSource gameSoundsSource1;

    private bool isPaused = false;

    public GameObject lives1;
    public GameObject lives2;
    public GameObject lives3;

    private GameManager manager;
    public int lives;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        backgroundMusicSource = manager.backgroundMusicSource;
        gameSoundsSource = manager.gameSoundsSource;
        gameSoundsSource1 = manager.gameSoundsSource1;

        pauseStuff.gameObject.SetActive(false);
        sliders.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);

        sliderMusic.value = 0.5f;
        sliderSounds.value = 0.5f;
        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);

        lives3.SetActive(true);
        lives2.SetActive(true);
        lives1.SetActive(true);
        lives = 3;
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseStuff.SetActive(true);
                sliders.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                isPaused = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseStuff.SetActive(false);
                sliders.gameObject.SetActive(false);
                menu.gameObject.SetActive(false);
                isPaused = false;
                Time.timeScale = 1.0f;
            }
        }

        backgroundMusicSource.volume = sliderMusic.value;
        gameSoundsSource.volume = sliderSounds.value;
        gameSoundsSource1.volume = sliderSounds.value;

        if (!lives1.activeInHierarchy)
        {
            DisplayLoseScreen();
        }
    }

    void Resume()
    {
        pauseStuff.SetActive(false);
        sliders.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void DisplayWinScreen()
    {
        winScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        sliderMusic.value = 0.1f;
        Time.timeScale = 0.0f;
    }

    void DisplayLoseScreen()
    {
        loseScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void DealDMG()
    {
        lives--;
        if (lives3.activeInHierarchy)
        {
            lives3.SetActive(false);
        }
        else if (lives2.activeInHierarchy)
        {
            lives2.SetActive(false);
        }
        else if (lives1.activeInHierarchy)
        {
            lives1.SetActive(false);
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}

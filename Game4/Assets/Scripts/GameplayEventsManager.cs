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

    private GameObject levelStatusHolder;
    private LevelUnlocker levelUnlocker;

    private TimeCounter timeCounter;
    private int timePassed;

    public Text scoreValue;
    private GameObject ScoreHolder;
    private HighscoreHolder highscoreHolder;

    void Awake()
    {
        levelStatusHolder = GameObject.FindGameObjectWithTag("LevelStatusHolder");
        DontDestroyOnLoad(levelStatusHolder);
        ScoreHolder = GameObject.FindGameObjectWithTag("HighscoreHolder");
        DontDestroyOnLoad(ScoreHolder);
    }

    void Start()
    {
        Time.timeScale = 1.0f;
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
        scoreValue.gameObject.SetActive(false);

        sliderMusic.value = 0.5f;
        sliderSounds.value = 0.5f;
        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);
        tryAgain.onClick.AddListener(RestartLevel);

        lives3.SetActive(true);
        lives2.SetActive(true);
        lives1.SetActive(true);
        lives = 3;
        
        levelUnlocker = levelStatusHolder.GetComponent<LevelUnlocker>();
        timeCounter = GetComponent<TimeCounter>();

        highscoreHolder = ScoreHolder.GetComponent<HighscoreHolder>();

    }

    void Update()
    {
        timePassed = int.Parse(timeCounter.counterValue.text);

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
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelUnlocker.isLVL2unlocked = true;
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            levelUnlocker.isLVL3unlocked = true;
        }
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        scoreValue.gameObject.SetActive(true);
        scoreValue.text = "" + CalculateAndSaveScore();
        Time.timeScale = 0.0f;
    }

    void DisplayLoseScreen()
    {
        loseScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        sliderMusic.value = 0.1f;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        Time.timeScale = 0.0f;
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
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

    public float CalculateAndSaveScore()
    {
        float result = 100.0f * lives * (1.0f / timePassed);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            highscoreHolder.highscore1 += result;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            highscoreHolder.highscore2 += result;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            highscoreHolder.highscore3 += result;
        }
        return result;
    }
}

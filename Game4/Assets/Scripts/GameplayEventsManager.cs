﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayEventsManager : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject sliders;

    public GameObject lives1;
    public GameObject lives2;
    public GameObject lives3;
    public GameObject savedInfo;

    public Button resume;
    public Button menu;
    public Button tryAgain;
    public Button saveScoreButton;

    public Slider sliderMusic;
    public Slider sliderSounds;

    public InputField nameInput;

    public Text scoreValue;


    private AudioSource backgroundMusicSource;
    private AudioSource gameSoundsSource;
    private AudioSource gameSoundsSource1;


    private GameObject ScoreHolder;
    private GameObject levelStatusHolder;


    private GameManager manager;
    private TimeCounter timeCounter;
    private LevelUnlocker levelUnlocker;
    private HighscoreHolder highscoreHolder;


    [HideInInspector]
    public int lives;
    public int isLVL2unlocked;
    public int isLVL3unlocked;
    private int timePassed;


    private bool isScoreSaved;
    private bool isPaused = false;


    void Awake()
    {
        levelStatusHolder = GameObject.FindGameObjectWithTag("LevelStatusHolder");
        DontDestroyOnLoad(levelStatusHolder);

        ScoreHolder = GameObject.FindGameObjectWithTag("HighscoreHolder");
        DontDestroyOnLoad(ScoreHolder);

        levelUnlocker = LevelPersistence.LoadData();

        isLVL2unlocked = levelUnlocker.isLVL2unlocked;
        isLVL3unlocked = levelUnlocker.isLVL3unlocked;
    }

    void OnDisable()
    {
        LevelPersistence.SaveData(isLVL2unlocked, isLVL3unlocked);
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        levelUnlocker = levelStatusHolder.GetComponent<LevelUnlocker>();
        highscoreHolder = ScoreHolder.GetComponent<HighscoreHolder>();
        timeCounter = GetComponent<TimeCounter>();

        backgroundMusicSource = manager.backgroundMusicSource;
        gameSoundsSource = manager.gameSoundsSource;
        gameSoundsSource1 = manager.gameSoundsSource1;

        pauseScreen.gameObject.SetActive(false);
        sliders.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        tryAgain.gameObject.SetActive(false);
        scoreValue.gameObject.SetActive(false);
        savedInfo.SetActive(false);

        sliderMusic.value = 0.5f;
        sliderSounds.value = 0.5f;

        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);
        tryAgain.onClick.AddListener(RestartLevel);
        saveScoreButton.onClick.AddListener(SaveScore);

        lives3.SetActive(true);
        lives2.SetActive(true);
        lives1.SetActive(true);
        lives = 3;

        isScoreSaved = false;
    }

    void Update()
    {
        timePassed = int.Parse(timeCounter.counterValue.text);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseScreen.SetActive(true);
                sliders.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                isPaused = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseScreen.SetActive(false);
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
        pauseScreen.SetActive(false);
        sliders.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        isPaused = false;

        Time.timeScale = 1.0f;
    }

    public void DisplayWinScreen()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        winScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        scoreValue.gameObject.SetActive(true);
        scoreValue.text = "" + CalculateScore();

        sliderMusic.value = 0.1f;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            levelUnlocker.isLVL2unlocked = 1;
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            levelUnlocker.isLVL3unlocked = 1;
        }

        Time.timeScale = 0.0f;
    }

    void DisplayLoseScreen()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        loseScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);

        sliderMusic.value = 0.1f;

        Time.timeScale = 0.0f;
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void DealDMG()
    {
        Debug.Log("I got dmg");
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
        lives--;
    }

    void GoToMenu()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1.0f;
    }

    public float CalculateScore()
    {
        float result = 10000000f * (float)lives*(float)(Math.PI/7.7) * (1f / (float)timePassed);

        return result;
    }

    public void SaveScore()
    {
        if(!isScoreSaved)
        {
            if(nameInput.text!="")
            {
                savedInfo.SetActive(true);
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    highscoreHolder.highscore1.Add(nameInput.text, CalculateScore());
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    highscoreHolder.highscore2.Add(nameInput.text, CalculateScore());
                }
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    highscoreHolder.highscore3.Add(nameInput.text, CalculateScore());
                }
                isScoreSaved = true;
            }
        }
    }
}

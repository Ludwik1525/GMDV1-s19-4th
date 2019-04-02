using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


    private GameManager manager;
    private TimeCounter timeCounter;

    private string filePath = "Assets/Resources/config.JSON";


    [HideInInspector]
    public int lives;
    public int isLVL2unlocked;
    public int isLVL3unlocked;
    private int timePassed;


    private bool isScoreSaved;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1.0f;

        manager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
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

        manager.SaveFile(filePath);
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
        winScreen.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        tryAgain.gameObject.SetActive(true);
        scoreValue.gameObject.SetActive(true);
        scoreValue.text = "" + CalculateScore();

        sliderMusic.value = 0.1f;

        //Should perhaps be handled in different place - it's own method
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            
            PlayerPrefs.SetInt("lvl2unlocked", 1);
            PlayerPrefs.Save();
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetInt("lvl3unlocked", 1);
            PlayerPrefs.Save();
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
            if(nameInput.text!="")
            {
                savedInfo.SetActive(true);
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    HighscoreHolder.highscore1.Add(nameInput.text, CalculateScore());
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    HighscoreHolder.highscore2.Add(nameInput.text, CalculateScore());
                }
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    HighscoreHolder.highscore3.Add(nameInput.text, CalculateScore());
                }
            }

            List<KeyValuePair<string, float>> lvl1scores = HighscoreHolder.highscore1.ToList();
        
            for (int i = 0; i < HighscoreHolder.highscore1.ToArray().Length; i++)
            {
                PlayerPrefs.SetString("score1Name" + i, lvl1scores[i].Key);
                PlayerPrefs.SetFloat("score1Value" + i, lvl1scores[i].Value);
            }

            List<KeyValuePair<string, float>> lvl2scores = HighscoreHolder.highscore2.ToList();

            for (int i = 0; i < HighscoreHolder.highscore2.ToArray().Length; i++)
            {
                PlayerPrefs.SetString("score2Name" + i, lvl2scores[i].Key);
                PlayerPrefs.SetFloat("score2Value" + i, lvl2scores[i].Value);
            }

            List<KeyValuePair<string, float>> lvl3scores = HighscoreHolder.highscore3.ToList();

            for (int i = 0; i < HighscoreHolder.highscore3.ToArray().Length; i++)
            {
                PlayerPrefs.SetString("score3Name" + i, lvl3scores[i].Key);
                PlayerPrefs.SetFloat("score3Value" + i, lvl3scores[i].Value);
            }

            PlayerPrefs.Save();
    }
}

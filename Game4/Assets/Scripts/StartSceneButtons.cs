using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneButtons : MonoBehaviour
{

    public Button newGameButton;
    public Button highscoreButton;
    public Button controlsButton;
    public Button exitButton;

    public Button backButton;
    public Button nextButton;

    public Button level1;
    public Button level2;
    public Button level3;

    public Text scores1;
    public Text scores2;
    public Text scores3;


    public GameObject menuButtons;
    public GameObject levelSelection;
    public GameObject highscoreMenu;
    public GameObject controlsMenu;
    public GameObject level1Menu;
    public GameObject level2Menu;
    public GameObject level3Menu;

    public GameObject paddlock2;
    public GameObject paddlock3;
    public GameObject text2;
    public GameObject text3;


    private GameObject levelStatusHolder;
    private GameObject ScoreHolder;

    public AudioSource source;

    public AudioClip buttonClick;
    public AudioClip backgroundMusic;

    private LevelUnlocker levelUnlocker;
    private HighscoreHolder highscoreHolder;


    public int lvl2unlocked;
    public int lvl3unlocked;


    void Awake()
    {
        levelStatusHolder = GameObject.FindGameObjectWithTag("LevelStatusHolder");
        DontDestroyOnLoad(levelStatusHolder);

        ScoreHolder = GameObject.FindGameObjectWithTag("HighscoreHolder");
        DontDestroyOnLoad(ScoreHolder);

        lvl2unlocked = PlayerPrefs.GetInt("isLVL2unlocked");
        lvl3unlocked = PlayerPrefs.GetInt("isLVL3unlocked");
    }

    void Start ()
    {
        levelUnlocker = levelStatusHolder.GetComponent<LevelUnlocker>();
        highscoreHolder = ScoreHolder.GetComponent<HighscoreHolder>();
        source = GetComponent<AudioSource>();

        menuButtons.gameObject.SetActive(true);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        level1Menu.gameObject.SetActive(false);
        level2Menu.gameObject.SetActive(false);
        level3Menu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        scores1.gameObject.SetActive(false);
        scores2.gameObject.SetActive(false);
        scores3.gameObject.SetActive(false);

        newGameButton.onClick.AddListener(ChooseLevel);
        highscoreButton.onClick.AddListener(OpenHighScore);
        controlsButton.onClick.AddListener(OpenControls);
        exitButton.onClick.AddListener(ExitGame);
        backButton.onClick.AddListener(BackToMenu);
        nextButton.onClick.AddListener(NextHighscore);

        level1.onClick.AddListener(StartLVL1);
        level2.onClick.AddListener(StartLVL2);
        level3.onClick.AddListener(StartLVL3);

        source.clip = backgroundMusic;
        source.loop = true;
        source.Play();

        lvl2unlocked = levelUnlocker.isLVL2unlocked;
        lvl3unlocked = levelUnlocker.isLVL3unlocked;

        if (lvl2unlocked==1)
        {
            UnlockLVL2();
        }

        if (lvl3unlocked==1)
        {
            UnlockLVL3();
        }

        SortAndSetHighscores();
    }

    void ChooseLevel()
    {
        source.PlayOneShot(buttonClick);

        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(true);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    void StartNewGame()
    {
        source.PlayOneShot(buttonClick);

        SceneManager.LoadScene(1);
    }

    void OpenHighScore()
    {
        source.PlayOneShot(buttonClick);

        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(true);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        level1Menu.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        scores1.gameObject.SetActive(true);
    }
    
    void OpenControls()
    {
        source.PlayOneShot(buttonClick);

        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    void BackToMenu()
    {
        source.PlayOneShot(buttonClick);

        menuButtons.gameObject.SetActive(true);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        level1Menu.gameObject.SetActive(false);
        level2Menu.gameObject.SetActive(false);
        level3Menu.gameObject.SetActive(false);

        scores1.gameObject.SetActive(false);
        scores2.gameObject.SetActive(false);
        scores3.gameObject.SetActive(false);
    }

    void StartLVL1()
    {
        SceneManager.LoadScene(1);
    }

    void StartLVL2()
    {
        SceneManager.LoadScene(2);
    }

    void StartLVL3()
    {
        SceneManager.LoadScene(3);
    }

    void ExitGame()
    {
        source.PlayOneShot(buttonClick);

        Application.Quit();
    }

    public void UnlockLVL2()
    {
        paddlock2.SetActive(false);
        text2.SetActive(true);
        level2.gameObject.SetActive(true);

        level2.GetComponent<Image>().color = Color.green;
    }

    public void UnlockLVL3()
    {
        paddlock3.SetActive(false);
        text3.SetActive(true);
        level3.gameObject.SetActive(true);

        level3.GetComponent<Image>().color = Color.green;
    }

    public void NextHighscore()
    {
        source.PlayOneShot(buttonClick);

        if (level1Menu.gameObject.activeInHierarchy)
        {
            level1Menu.gameObject.SetActive(false);
            level2Menu.gameObject.SetActive(true);
            level3Menu.gameObject.SetActive(false);
            scores1.gameObject.SetActive(false);
            scores2.gameObject.SetActive(true);
            scores3.gameObject.SetActive(false);
        }
        else if (level2Menu.gameObject.activeInHierarchy)
        {
            level1Menu.gameObject.SetActive(false);
            level2Menu.gameObject.SetActive(false);
            level3Menu.gameObject.SetActive(true);
            scores1.gameObject.SetActive(false);
            scores2.gameObject.SetActive(false);
            scores3.gameObject.SetActive(true);
        }
        else if (level3Menu.gameObject.activeInHierarchy)
        {
            level1Menu.gameObject.SetActive(true);
            level2Menu.gameObject.SetActive(false);
            level3Menu.gameObject.SetActive(false);
            scores1.gameObject.SetActive(true);
            scores2.gameObject.SetActive(false);
            scores3.gameObject.SetActive(false);
        }
    }

    void SortAndSetHighscores()
    {
        List<KeyValuePair<string, float>> lvl1scores = highscoreHolder.highscore1.ToList();

        lvl1scores.Sort(delegate (KeyValuePair<string, float> pair1, KeyValuePair<string, float> pair2)
        {
            return pair2.Value.CompareTo(pair1.Value);
        });

        List<KeyValuePair<string, float>> lvl2scores = highscoreHolder.highscore2.ToList();

        lvl2scores.Sort(delegate (KeyValuePair<string, float> pair1, KeyValuePair<string, float> pair2)
        {
            return pair2.Value.CompareTo(pair1.Value);
        });

        List<KeyValuePair<string, float>> lvl3scores = highscoreHolder.highscore3.ToList();

        lvl3scores.Sort(delegate (KeyValuePair<string, float> pair1, KeyValuePair<string, float> pair2)
        {
            return pair2.Value.CompareTo(pair1.Value);
        });

        for (int i = 0; i < highscoreHolder.highscore1.ToArray().Length; i++)
        {
            scores1.text += lvl1scores[i];
            scores1.text += "\n";
        }

        for (int i = 0; i < highscoreHolder.highscore2.ToArray().Length; i++)
        {
            scores2.text += lvl2scores[i];
            scores2.text += "\n";
        }

        for (int i = 0; i < highscoreHolder.highscore3.ToArray().Length; i++)
        {
            scores3.text += lvl3scores[i];
            scores3.text += "\n";
        }
    }


}

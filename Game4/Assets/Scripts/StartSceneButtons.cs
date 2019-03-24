using System.Collections;
using System.Collections.Generic;
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

    public GameObject menuButtons;
    public GameObject levelSelection;
    public GameObject highscoreMenu;
    public GameObject controlsMenu;

    public AudioSource source;
    public AudioClip buttonClick;
    public AudioClip backgroundMusic;

	void Start ()
    {

        source = GetComponent<AudioSource>();

        menuButtons.gameObject.SetActive(true);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        newGameButton.onClick.AddListener(ChooseLevel);
        highscoreButton.onClick.AddListener(OpenHighScore);
        controlsButton.onClick.AddListener(OpenControls);
        exitButton.onClick.AddListener(ExitGame);
        backButton.onClick.AddListener(BackToMenu);

        source.clip = backgroundMusic;
        source.loop = true;
        source.Play();
    }
	
	void Update () {
	
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
    }

    void ExitGame()
    {
        source.PlayOneShot(buttonClick);

        Application.Quit();
    }
}

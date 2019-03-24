using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneButtons : MonoBehaviour
{

    public Button newGameButton;
    public Button startGameButton;
    public Button highscoreButton;
    public Button controlsButton;
    public Button exitButton;
    public Button backButton;

    public GameObject menuButtons;
    public GameObject levelSelection;
    public GameObject highscoreMenu;
    public GameObject controlsMenu;

	void Start () {

        menuButtons.gameObject.SetActive(true);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        newGameButton.onClick.AddListener(ChooseLevel);
        startGameButton.onClick.AddListener(StartNewGame);
        highscoreButton.onClick.AddListener(OpenHighScore);
        controlsButton.onClick.AddListener(OpenControls);
        exitButton.onClick.AddListener(ExitGame);
        backButton.onClick.AddListener(BackToMenu);
	}
	
	void Update () {
	
	}

    void ChooseLevel()
    {
        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(true);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    void OpenHighScore()
    {
        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(true);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }
    
    void OpenControls()
    {
        menuButtons.gameObject.SetActive(false);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    void BackToMenu()
    {
        menuButtons.gameObject.SetActive(true);
        levelSelection.gameObject.SetActive(false);
        highscoreMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}

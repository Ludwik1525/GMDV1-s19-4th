using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

[System.Serializable]
public class GameManager : MonoBehaviour
{

    private string configFilePath = "Assets/Resources/config.JSON";
    private string levelProgressFilePath = "Assets/Resources/levelProgress.JSON";
    private string highscoreFilePath = "Assets/Resources/highscore.JSON";

    [Range(1f, 4f)]
    public float playerSpeed;
    [Range(1f, 4f)]
    public float wormsSpeed;
    [Range(1f, 3f)]
    public float golemSpeed;
    [Range(1f, 6f)]
    public float blackmanSpeed;
    [Range(1f, 5f)]
    public float skeletonSpeed;
    [Range(3f, 8f)]
    public float flameSpeed;
    [Range(1f, 6f)]
    public float spiderSpeed;

    public AudioSource gameSoundsSource;
    public AudioSource gameSoundsSource1;
    public AudioSource backgroundMusicSource;

    public AudioClip playerWalkingSound;
    public AudioClip playerReceiveDMGSound;
    public AudioClip playerDeathSound;
    public AudioClip levelCompletedSound;

    void Start () {
		LoadConfigFile();
        LoadHighscoreFile();
        LoadLevelProgressFile();
	}
    
    public void LoadConfigFile()
    {
        if (File.Exists(configFilePath))
        {
            string dataInJson = File.ReadAllText(configFilePath);
            string loadedData = JsonUtility.FromJson<string>(dataInJson);

            Debug.Log(dataInJson);
        }
        else
        {
            Debug.LogError("Config file broken!");
        }
    }

    public void LoadHighscoreFile()
    {
        if (File.Exists(levelProgressFilePath))
        {
            string dataInJson = File.ReadAllText(configFilePath);
            string loadedData = JsonUtility.FromJson<string>(dataInJson);
            
        }
        else
        {
            Debug.LogError("Highscore file broken!");
        }
    }

    public void LoadLevelProgressFile()
    {
        if (File.Exists(highscoreFilePath))
        {
            string dataInJson = File.ReadAllText(configFilePath);
            string loadedData = JsonUtility.FromJson<string>(dataInJson);
            
        }
        else
        {
            Debug.LogError("LevelProgress file broken!");
        }
    }

}

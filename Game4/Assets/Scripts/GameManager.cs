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

    [Range(1f, 4f)]
    public float playerSpeed;
    [Range(1f, 4f)]
    public float wormsSpeed;
    public AudioSource gameSoundsSource;
    public AudioSource gameSoundsSource1;
    public AudioSource backgroundMusicSource;
    public AudioClip playerWalkingSound;
    public AudioClip playerReceiveDMGSound;
    public AudioClip playerDeathSound;
    public AudioClip levelCompletedSound;

    void Start () {
		LoadConfigFile();
	}

	void Update () {
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

    void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    
}

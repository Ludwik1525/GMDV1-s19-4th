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

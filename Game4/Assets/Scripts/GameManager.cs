﻿using System.Collections;
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
		LoadFile(configFilePath);
	}
    
    public void LoadFile(string path)
    {
        if (File.Exists(path))
        {
            string dataInJson = File.ReadAllText(path);
            string loadedData = JsonUtility.FromJson<string>(dataInJson);

            Debug.Log(dataInJson);
        }
        else
        {
            Debug.LogError("File broken!");
        }
    }



}

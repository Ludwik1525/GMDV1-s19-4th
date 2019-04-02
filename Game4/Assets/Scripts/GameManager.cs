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
    //singleton pattern 
    public static GameManager instance = null;
    private string configFilePath = "Assets/Resources/config.JSON";
    private string dataInJson;

    private Speed speed;

    [HideInInspector]
    public float playerSpeed;
    [HideInInspector]
    public float wormsSpeed;
    [HideInInspector]
    public float golemSpeed;
    [HideInInspector]
    public float blackmanSpeed;
    [HideInInspector]
    public float skeletonSpeed;
    [HideInInspector]
    public float flameSpeed;
    [HideInInspector]
    public float spiderSpeed;

    public AudioSource gameSoundsSource;
    public AudioSource gameSoundsSource1;
    public AudioSource backgroundMusicSource;

    public AudioClip playerWalkingSound;
    public AudioClip playerReceiveDMGSound;
    public AudioClip playerDeathSound;
    public AudioClip levelCompletedSound;


    void Awake()
    {
        //singleton pattern
        if(instance == null){
            instance = this;
        }else if (instance != this)
            Destroy(gameObject);

    }
    void Start ()
    {  speed=new Speed();
        LoadFile(configFilePath);
	}

    public void LoadFile(string path)
    {
            dataInJson = File.ReadAllText(path);
            speed = JsonUtility.FromJson<Speed>(dataInJson);

            playerSpeed = speed.playerSpeed;
            wormsSpeed = speed.wormsSpeed;
            golemSpeed = speed.golemSpeed;
            blackmanSpeed = speed.blackmanSpeed;
            skeletonSpeed = speed.blackmanSpeed;
            flameSpeed = speed.flameSpeed;
            spiderSpeed = speed.spiderSpeed;

            print(playerSpeed);

    }

    public void SaveFile(string path)
    {
        speed.blackmanSpeed = blackmanSpeed;
        speed.flameSpeed = flameSpeed;
        speed.golemSpeed = golemSpeed;
        speed.playerSpeed = playerSpeed;
        speed.spiderSpeed = spiderSpeed;
        speed.wormsSpeed = wormsSpeed;
        speed.skeletonSpeed = skeletonSpeed;

        dataInJson = JsonUtility.ToJson(speed, false);
        File.WriteAllText(path, dataInJson);
    }






}

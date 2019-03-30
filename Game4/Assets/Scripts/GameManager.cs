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
		
    //    LoadFile(configFilePath);
       LoadFile(highscoreFilePath);
       LoadFile(levelProgressFilePath);

       saveJson(configFilePath);

	}
    
   

    public void LoadFile(string path)
    {
        if (File.Exists(path))
        {
            string dataInJson = File.ReadAllText(path);
            string loadedData = JsonUtility.FromJson<string>(dataInJson);
            
        }
        else
        {
            Debug.LogError("File broken!");
        }
    }

    public void saveJson(string path){
        JsonTesting test = new JsonTesting();
        string [] jsonArray = new string [3];

        if (File.Exists(path))
        {

        test.testFloat = 0.5f; 
        jsonArray[0] = test.testFloat.ToString();
        test.testString = "Goodbye world";
        jsonArray[1] = test.testString;
        test.testInt = 60;
        jsonArray[2] = test.testInt.ToString();

           
           File.WriteAllLines(path,jsonArray);
           print(File.ReadAllLines(path));
        }

        print(JsonUtility.ToJson(test));

    }

    

}

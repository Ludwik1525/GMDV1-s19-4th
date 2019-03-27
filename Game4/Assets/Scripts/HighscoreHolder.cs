using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHolder : MonoBehaviour
{
    //dictionaries storing the player nickname and their score
    public Dictionary<string, float> highscore1;
    public Dictionary<string, float> highscore2;
    public Dictionary<string, float> highscore3;

    void Awake ()
    {
        //keep the dictionaries between scenes
        highscore1 = new Dictionary<string, float>();
        highscore2 = new Dictionary<string, float>();
        highscore3 = new Dictionary<string, float>();
        DontDestroyOnLoad(this.gameObject);
    }
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighscoreHolder
{
    //dictionaries storing the player nickname and their score
     
    public static Dictionary<string, float> highscore1;
    public static Dictionary<string, float> highscore2;
    public static Dictionary<string, float> highscore3;

   /* void Awake ()
    {
        //keep the dictionaries between scenes
        highscore1 = new Dictionary<string, float>();
        highscore2 = new Dictionary<string, float>();
        highscore3 = new Dictionary<string, float>();
        DontDestroyOnLoad(this.gameObject);
    }*/
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHolder : MonoBehaviour
{
    public Dictionary<string, float> highscore1;
    public Dictionary<string, float> highscore2;
    public Dictionary<string, float> highscore3;

    void Awake ()
    {
        highscore1 = new Dictionary<string, float>();
        highscore2 = new Dictionary<string, float>();
        highscore3 = new Dictionary<string, float>();
        DontDestroyOnLoad(this.gameObject);
    }
	
}

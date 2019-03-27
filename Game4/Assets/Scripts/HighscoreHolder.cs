using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreHolder : MonoBehaviour
{
    public string highscore1;
    public string highscore2;
    public string highscore3;

    void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	
}

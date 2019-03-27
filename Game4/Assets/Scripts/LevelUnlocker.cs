using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{

    //integers to store level progress (playerprefs do not work with bools)
    public int isLVL2unlocked { get; set; }
    public int isLVL3unlocked { get; set; }

   
    void Awake()
    {
        //keep the object holding the progress between scenes
        DontDestroyOnLoad(this.gameObject);
    }
    
}

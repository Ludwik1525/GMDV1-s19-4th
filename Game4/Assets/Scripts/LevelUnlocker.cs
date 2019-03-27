using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{

    public int isLVL2unlocked { get; set; }
    public int isLVL3unlocked { get; set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}

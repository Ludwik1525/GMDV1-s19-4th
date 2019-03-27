using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{

    public bool isLVL2unlocked;
    public bool isLVL3unlocked;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelPersistence{

    public static LevelUnlocker LoadData()
    {
        int lv2 = PlayerPrefs.GetInt("isLVL2unlocked");
        int lv3 = PlayerPrefs.GetInt("isLVL3unlocked");

        LevelUnlocker levelData = new LevelUnlocker()
        {
            isLVL2unlocked = lv2,
            isLVL3unlocked = lv3
        };

        return levelData;
    }

    public static void SaveData(GameplayEventsManager manager)
    {
        PlayerPrefs.SetInt("isLVL2unlocked",manager.levelUnlocker.isLVL2unlocked);
        PlayerPrefs.SetInt("isLVL3unlocked",manager.levelUnlocker.isLVL3unlocked);
    }
}

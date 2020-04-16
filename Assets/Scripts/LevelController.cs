using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public List<Level> levels;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<LevelController>().Length > 1)
        {
            Destroy(gameObject);
        }
        levels = new List<Level>
        {
            new Level(0, "Introduction", true, 2, false),
            new Level(1, "Getting Goin'", false, 0, false),
            new Level(3, "Yee-haw", false, 0, true),
            new Level(4, "Yee-haw", false, 0, true),
            new Level(5, "Yee-haw", false, 0, true),
            new Level(6, "Yee-haw", false, 0, true),
            new Level(7, "Yee-haw", false, 0, true),
            new Level(8, "Yee-haw", false, 0, true),
            new Level(9, "Yee-haw", false, 0, true),
            new Level(10, "Yee-haw", false, 0, true),
            new Level(11, "Yee-haw", false, 0, true),            
            new Level(12, "Yee-haw", false, 0, true),
            new Level(13, "Yee-haw", false, 0, true),
            new Level(14, "Yee-haw", false, 0, true),
            new Level(15, "Yee-haw", false, 0, true)
        };
    }

    public void StartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Complete();
    }

    public void CompleteLevel(string levelName, int stars)
    {
        levels.Find(i => i.LevelName == levelName).Complete(stars);
    }

    public void LockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Lock();
    }

    public void UnlockLevel(string levelName)
    {
        levels.Find(i => i.LevelName == levelName).Unlock();
    }
}

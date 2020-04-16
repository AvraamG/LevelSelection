using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _instance;
    public static LevelManager Instance { get => _instance; }
    #endregion

    [SerializeField]
    public List<Level> _allLevels;

    public int _currentLevelPointer;
    private Level lastplayedLevel;

    private void Initialize()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            if (_allLevels.Count == 0)
            {

                _allLevels.Add(new Level(0, "Tutorial"));
                _allLevels.Add(new Level(1, "My First Level"));
                _allLevels.Add(new Level(2, "My Second Level"));
                _allLevels.Add(new Level(3, "My Third Level"));


            }
            _currentLevelPointer = 0;
            lastplayedLevel = _allLevels[_currentLevelPointer];
        }

    }

    //Logic will be that you complete one, you get the animation of completion. You unlock the next.

    public void CompleteCurrentLevel()
    {
        lastplayedLevel.CompleteLevel();
    }



    public void LoadLevel(string levelName)
    {

        try
        {
            SceneManager.LoadScene(levelName);

        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void LoadLastPlayedLevel()
    {
        if (lastplayedLevel)
        {
            SceneManager.LoadScene(lastplayedLevel.Id);
        }
    }

    public void LoadSpecificLevel(Level targetLevel)
    {
        if (targetLevel)
        {
            SceneManager.LoadScene(targetLevel.Id);
        }
    }



    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    /*
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
    */
}

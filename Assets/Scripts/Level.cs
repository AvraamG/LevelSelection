using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelStatus
    {
        Locked=0,
        Available=1,
        Completed=2
    }
    #region Attributes

    private readonly int _id;
    private readonly string _levelName;
    private int _ammountOfStars;
    private LevelStatus _status;

    public int Id { get { return _id; } }
    public string LevelName { get { return _levelName; } }
    public int AmmountOfStars { get { return _ammountOfStars; } }
    public LevelStatus Status { get { return _status; } }

    #endregion


    public Level(int newID, string newLevelName, int newAmmountOfStars, LevelStatus newLevelStatus)
    {
        this._id = newID;
        this._levelName = newLevelName;
        this._ammountOfStars = newAmmountOfStars;
        this._status = newLevelStatus;
    }

    public Level(int newID, string newLevelName)
    {
        this._id = newID;
        this._levelName = newLevelName;
        this._ammountOfStars = 0;
        this._status = LevelStatus.Locked;
    }


    public void CompleteLevel()
    {
        this._ammountOfStars = 1;
        this._status = LevelStatus.Completed;
    }
    public void CompleteLevel(int ammountOfStars)
    {
        this._ammountOfStars = ammountOfStars;
        this._status = LevelStatus.Completed;
    }

    public void UnlockLevel()
    {
        this._status = LevelStatus.Available;
    }

    public void LockLevel()
    {
        this._status = LevelStatus.Locked;
    }

    // Start is called before the first frame update
    private void Start()
    {




    }

    // Update is called once per frame
    private void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour {


    [SerializeField] private UILevel levelUI;
    [SerializeField] private LevelPopup levelPopup;

    private Transform levelSelectPanel;
    private int currentPage;
    private List<UILevel> levelList = new List<UILevel>();

	// Use this for initialization
	void Start () {
        levelSelectPanel = transform;

        for (int i = 0; i < LevelManager.Instance._allLevels.Count; i++)
        {
            levelList.Add(levelUI);
        }
        BuildLevelPage(0);
    }
	
    void BuildLevelPage(int page)
    {
        RemoveItemsFromPage();
        currentPage = page;
        int pageSize = 12;
        List<UILevel> pageList = levelList.Skip(page * pageSize).Take(pageSize).ToList();

        for(int i = 0; i < pageList.Count; i++)
        {
            Level level = LevelManager.Instance._allLevels[(page * pageSize) + i];
            UILevel instance = Instantiate(pageList[i]);
            instance.SetStars(level.AmmountOfStars);
            instance.transform.SetParent(levelSelectPanel);
            instance.GetComponent<Button>().onClick.AddListener(() => SelectLevel(level));

            if (level.Status != Level.LevelStatus.Locked)
            {
                instance.lockImage.SetActive(false);
                instance.levelIDText.text = level.Id.ToString();
            }
            else
            {
                instance.lockImage.SetActive(true);
                instance.levelIDText.text = "";
            }
        }
    }

    void RemoveItemsFromPage()
    {
        for (int i = 0; i < levelSelectPanel.childCount; i++)
        {
            Destroy(levelSelectPanel.GetChild(i).gameObject);
        }
    }

    public void NextPage()
    {
        BuildLevelPage(currentPage + 1);
    }

    public void PreviousPage()
    {
        BuildLevelPage(currentPage - 1);
    }

    void SelectLevel(Level level)
    {
        if (level.Status == Level.LevelStatus.Locked)
        {
            levelPopup.gameObject.SetActive(true);
            levelPopup.SetText("<b>Level " + level.Id + " is currently locked.</b>\nComplete level " + (level.Id-1) + " to unlock it!");
            Debug.Log("Level locked.");
        }
        else
        {
            Debug.Log("Go to level: " + level.Id);
            LevelManager.Instance.LoadSpecificLevel (level);
        }
    }
}

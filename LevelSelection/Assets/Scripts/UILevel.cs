using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour {
    public Level level;
    public Text levelIDText;
    private Transform starParent;
    public GameObject lockImage;
    private Image[] stars;
    
    void Awake()
    {
        starParent = transform.Find("Stars").transform;
        stars = starParent.GetComponentsInChildren<Image>();
    }

    public void SetStars(int stars)
    {
        for(int i = 0; i < stars; i++)
        {
            this.stars[i].color = Color.white;
            Debug.Log("White!");
        }
    } 
}

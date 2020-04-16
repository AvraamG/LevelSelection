using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private LevelController levelController;

    void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        Debug.Log(levelController);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            levelController.CompleteLevel("Introduction", 2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            levelController.StartLevel("LevelSelect");
        }
    }
}

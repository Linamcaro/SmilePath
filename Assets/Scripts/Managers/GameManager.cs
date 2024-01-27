using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SceneChanger))]
public class GameManager : MonoBehaviour
{
    public Action<ENUM_Levels> OnLevelComplete;
    [HideInInspector] public ENUM_Levels lastCompletedLevel;
    
    private SceneChanger _sceneChanger;

    //Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null) _instance = GetComponent<GameManager>();
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _sceneChanger = GetComponent<SceneChanger>();
    }

    public void TriggerLevelComplete(ENUM_Levels completedLevel)
    {
        OnLevelComplete?.Invoke(completedLevel);
        lastCompletedLevel = completedLevel;
        switch (completedLevel)
        {
            case ENUM_Levels.Level1:
                ChangeScene(0, true);
                break;
            case ENUM_Levels.Level2:
                ChangeScene(1, true);
                break;
        }
    }

    public void ChangeScene(int targetSceneIndex, bool doFade = false)
    {
        StartCoroutine(_sceneChanger.ChangeScene(targetSceneIndex, doFade));
    }
}

public enum ENUM_Levels
{
    None,
    Level1,
    Level2
}
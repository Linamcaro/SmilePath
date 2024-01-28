using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SceneChanger))]
public class GameManager : MonoBehaviour
{
    [HideInInspector] public ENUM_Levels lastCompletedLevel;
    public Action<ENUM_Levels> OnLevelComplete;
    public List<ENUM_Levels> CompletedLevels;

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
        CompletedLevels.Add(completedLevel);
        if(CompletedLevels.Count < 2)
        {
            ChangeScene(2, true);
        }
        else
        {
            ChangeScene(5, true);
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
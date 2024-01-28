using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorRoomController : MonoBehaviour
{
    public List<LevelsStruct> AvaiableLevels;
    public List<CollectedItemInRoom> CollectedItemsInRoom;

    // Start is called before the first frame update
    void Start()
    {
        CheckCompletedLevels(GameManager.Instance.CompletedLevels);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToRandomLevel();
        }
    }

    private void CheckCompletedLevels(List<ENUM_Levels> completedLevels)
    {
        foreach (ENUM_Levels level in completedLevels)
        {
            foreach (LevelsStruct avaiableLevel in AvaiableLevels)
            {
                if (avaiableLevel.LevelEnum == level)
                {
                    AvaiableLevels.Remove(avaiableLevel);
                    break;
                }
            }

            foreach (CollectedItemInRoom item in CollectedItemsInRoom)
            {
                if (item.ContainingLevel == level)
                {
                    item.ItemObject.SetActive(true);
                    break;
                }
            }
        }
    }

    public void GoToRandomLevel()
    {
        if(AvaiableLevels.Count > 0)
        {
            int targetSceneIndex = UnityEngine.Random.Range(0, AvaiableLevels.Count);
            GameManager.Instance.ChangeScene(AvaiableLevels[targetSceneIndex].Index, true);
        }
    }
}

[Serializable]
public struct CollectedItemInRoom{
    public ENUM_Levels ContainingLevel;
    public GameObject ItemObject;
}

[Serializable]
public struct LevelsStruct
{
    public ENUM_Levels LevelEnum;
    public int Index;
}

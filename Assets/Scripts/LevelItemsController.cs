using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelItemsController : MonoBehaviour
{
    public int ItemsTomados = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarItem()
    {
        ItemsTomados += 1;
        if (ItemsTomados >= 2)
        {
            if (SceneManager.GetActiveScene().name == "Level_1")
                GameManager.Instance.TriggerLevelComplete(ENUM_Levels.Level1);
            else if (SceneManager.GetActiveScene().name == "Level2")
                GameManager.Instance.TriggerLevelComplete(ENUM_Levels.Level2);
        }
    }
}

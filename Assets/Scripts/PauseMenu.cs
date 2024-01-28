using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePause = false;
    public GameObject PauseMenuUI;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        if ((Input.GetKeyDown(KeyCode.P)) &&(GamePause==true))
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePause = false;
            GameManager.Instance.ChangeScene(2,true);
        }

    }
    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        Cursor.visible = false; // Show the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }
}

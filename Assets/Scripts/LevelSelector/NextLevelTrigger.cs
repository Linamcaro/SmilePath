using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = false;
            var levelRoomController = GameObject.Find("LevelController").GetComponent<LevelSelectorRoomController>();
            levelRoomController.GoToRandomLevel();
        }
    }
}

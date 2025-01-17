using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicSO", menuName = "Sounds/Music")]
public class MusicSO : ScriptableObject
{
    public AudioClip mainMenuMusic;
    public AudioClip LevelSelectorRoomMusic;
    public AudioClip Level1Music;
    public AudioClip Level2Music;
}

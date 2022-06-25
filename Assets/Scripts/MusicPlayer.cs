using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // This is the implementation of the Singleton Pattern for the Music Player,
    // to avoid it looping every time the scene reloads
    void Awake() {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(this.gameObject);  
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

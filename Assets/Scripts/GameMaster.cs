using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public int EnemiesAlive = 0;

    public bool played = false;

    public AudioClip level_complete;
    private AudioSource audio;

    public int score = 0;


    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (EnemiesAlive <= 0 && played == false)
        {
            PlayerLevelComplete();
        }
    }


    private void PlayerLevelComplete()
    {
        played = true;
        audio.PlayOneShot(level_complete);
    }

    public void PlayDeathSound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}

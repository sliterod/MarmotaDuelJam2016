﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectRooms : MonoBehaviour {

    Difficulty currentDifficulty;
    GameObject[] rooms;

    public Difficulty CurrentDifficulty
    {
        get
        {
            return currentDifficulty;
        }

        set
        {
            currentDifficulty = value;
        }
    }

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
	}

    /// <summary>
    /// Chooses between a set of easy scenarios
    /// </summary>
    void RandomEasy()
    {
        //SceneManager.LoadScene("Easy1");
        SceneManager.LoadScene("loader");
    }

    /// <summary>
    /// Chooses between a set of normal scenario
    /// </summary>
    void RandomNormal()
    {
        //SceneManager.LoadScene("Normal1");
        SceneManager.LoadScene("loader");
    }

    /// <summary>
    /// Chooses between a set of insane scenarios
    /// </summary>
    void RandomInsane()
    {
        SceneManager.LoadScene("Insane");
    }

    /// <summary>
    /// Randomizes scenarios according to difficulty selected
    /// </summary>
    /// <param name="diff"></param>
    public void RandomizeScenes(Difficulty diff) {

        currentDifficulty = diff;

        switch (currentDifficulty) {
            case Difficulty.easy:
                RandomEasy();
                break;

            case Difficulty.normal:
                RandomNormal();
                break;

            case Difficulty.insane:
                RandomInsane();
                break;
        }
    }
}

using UnityEngine;
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

        currentDifficulty = Difficulty.normal;
	}

    void RandomizeRooms() {

    }
}

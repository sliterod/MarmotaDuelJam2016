using UnityEngine;
using System.Collections;

public class TutorialRoom : RoomController {

    Difficulty fixedDiff;

	// Use this for initialization
	void Start () {
        fixedDiff = Difficulty.easy;
        CheckDifficulty(fixedDiff);
	}
}

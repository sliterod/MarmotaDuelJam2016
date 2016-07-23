using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour{

    bool hintActivatedAfterDeath;

    public bool HintActivatedAfterDeath
    {
        get
        {
            return hintActivatedAfterDeath;
        }

        set
        {
            hintActivatedAfterDeath = value;
        }
    }

    /// <summary>
    /// Checks difficulty level to show hints on current room
    /// </summary>
    /// <param name="diffLevel"></param>
    protected void CheckDifficulty(Difficulty diffLevel) {
        switch (diffLevel) {
            case Difficulty.easy:
                ShowHints();
                break;

            case Difficulty.normal:
                FlagHints();
                break;

            case Difficulty.insane:
                HideHints();
                break;
        }
    }

    /// <summary>
    /// Prevents hints from being shown
    /// </summary>
    void HideHints() {
        Debug.Log("Difficulty set on Insane. Hiding all hints");
    }

    /// <summary>
    /// Show all hints on current room
    /// </summary>
    void ShowHints (){
        Debug.Log("Difficulty set on Easy. Showing all hints");
    }

    /// <summary>
    /// Activates a flag to show a hint after the first death on the room
    /// </summary>
    void FlagHints() {
        Debug.Log("Difficulty set on Normal. Hints are set to be shown after first death.");
        hintActivatedAfterDeath = true;
    }
}
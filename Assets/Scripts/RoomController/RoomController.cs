using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

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
        //this.transform.FindChild("Helpers").gameObject.SetActive(false);
    }

    /// <summary>
    /// Show all hints on current room
    /// </summary>
    void ShowHints() {
        Debug.Log("Difficulty set on Easy. Showing all hints");
        EasyHints();
    }

    /// <summary>
    /// Activates a flag to show a hint after the first death on the room
    /// </summary>
    void FlagHints() {
        Debug.Log("Difficulty set on Normal. Hints are set to be shown after first death.");
        hintActivatedAfterDeath = true;
    }

    /// <summary>
    /// Searchs for all object animators and activate their triggers to display
    /// all the hints on the current room
    /// </summary>
    void EasyHints() {

        GameObject[] torches;
        GameObject[] beastDoor;

        //Getting all objects
        torches = GameObject.FindGameObjectsWithTag("torch");
        beastDoor = GameObject.FindGameObjectsWithTag("beast");

        //Triggering all waiting animations
        //Torches
        foreach (GameObject go in torches) {
            go.GetComponent<Animator>().SetTrigger("turnOffHint");
        }

        //Beast door
        /*foreach (GameObject go in beastDoor)
        {
            go
        }*/
    }

    /// <summary>
    /// Show hints after death in normal mode
    /// </summary>
    void NormalHints() {
        GameObject[] torches;
        GameObject[] redLevers;
        GameObject[] greenLevers;
        GameObject[] beastDoor;

        //Getting all objects
        torches = GameObject.FindGameObjectsWithTag("torch");
        redLevers = GameObject.FindGameObjectsWithTag("redLever");
        greenLevers = GameObject.FindGameObjectsWithTag("greenLever");
        beastDoor = GameObject.FindGameObjectsWithTag("beast");

        //Triggering all waiting animations
        //Torches
        foreach (GameObject go in torches)
        {
            go.GetComponent<Animator>().SetTrigger("turnOffHint");
        }

        //Red lever
        foreach (GameObject go in redLevers)
        {
            go.GetComponent<Animator>().SetBool("isPlaying", true);
        }

        //Green lever
        foreach (GameObject go in greenLevers)
        {
            go.GetComponent<Animator>().SetBool("isPlaying", true);
        }
    } 
}
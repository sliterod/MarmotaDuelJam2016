using UnityEngine;
using System.Collections;

public class TorchEvent : MonoBehaviour {

    public BoxCollider2D affectedObject;

    bool isTorchOff;    //Check if torch is off
    bool isTorchFlip;   //Check if torch is flipped

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click on element");

            PlayAnimation();
            PlaySound();
        }
    }

    /// <summary>
    /// Deactivates hazard associated to this object
    /// </summary>
    void DeactivateHazard()
    {
        if (affectedObject)
        {
            affectedObject.enabled = false;
            affectedObject.SendMessage("DisableHazard", SendMessageOptions.DontRequireReceiver);
        }
    }

    /// <summary>
    /// Plays object animation
    /// </summary>
    void PlayAnimation()
    {
        Animator animator;
        animator = this.GetComponent<Animator>();

        animator.SetTrigger("turnOff");

        DeactivateHazard();
    }


    /// <summary>
    /// Plays object sound
    /// </summary>
    void PlaySound()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>()
            .PlayPuzzleOK();
    }
}

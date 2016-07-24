using UnityEngine;
using System.Collections;

public class ClickEvents : MonoBehaviour {

    public BoxCollider2D affectedObject;

    void OnMouseDown() {      
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Click on element");

            PlayAnimation();
            PlaySound();
        }
    }

    /// <summary>
    /// Deactivates hazard associated to this object
    /// </summary>
    void DeactivateHazard() {
        if (affectedObject) { 
            affectedObject.enabled = false;
            affectedObject.SendMessage("DisableHazard",SendMessageOptions.DontRequireReceiver);
        }
    }

    /// <summary>
    /// Plays object animation
    /// </summary>
    void PlayAnimation() {
        Animator animator;
        animator = this.GetComponent<Animator>();

        animator.SetBool("isPlaying", true);

        DeactivateHazard();
    }

    /// <summary>
    /// Plays object sound
    /// </summary>
    void PlaySound() {
        GameObject.Find("SoundManager").GetComponent<SoundManager>()
            .PlayPuzzleOK();
    }
}

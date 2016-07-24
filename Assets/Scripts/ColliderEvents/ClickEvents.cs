using UnityEngine;
using System.Collections;

public class ClickEvents : MonoBehaviour {

    public BoxCollider2D affectedObject;

    void OnMouseDown() {      
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Click on element");

            PlayAnimation();
        }
    }

    /// <summary>
    /// Deactivates hazard associated to this object
    /// </summary>
    void DeactivateHazard() {
        affectedObject.enabled = false;
        affectedObject.SendMessage("DisableHazard",SendMessageOptions.DontRequireReceiver);
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
}

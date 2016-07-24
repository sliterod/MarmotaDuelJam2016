using UnityEngine;
using System.Collections;

public class ColliderEvents : MonoBehaviour {

    CharacterAction characterAction;
    CamZoom cameraZoom;
    Animator animator;

    bool isCharacterJumping;
    bool isCharacterClimbing;

    void Start() {
        characterAction = this.GetComponent<CharacterAction>();
        cameraZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamZoom>();
    
        animator = this.GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D triggerCollider) {
        
        if (triggerCollider.tag == "jump" && !isCharacterJumping)
        {
            Debug.Log("Send message to jump method");
            characterAction.isJumping = true;
            isCharacterJumping = true;
            
            animator.SetTrigger("isJumping");
        }

        if (triggerCollider.tag == "hazard")
        {
            Debug.Log("Hazard! Restarting game");
            GameObject.Find("Gamestate").SendMessage("BottomPit");
        }

        if (triggerCollider.tag == "climb" && !isCharacterClimbing)
        {
            Debug.Log("Send message to climb method");

            characterAction.isClimbing = true;
            isCharacterClimbing = true;
            GameObject.Find("Gamestate").SendMessage("ActivateClimb");
        }

        if (triggerCollider.tag == "zoomIn")
        {
            Debug.Log("Send message to zoom In method");
            cameraZoom.ZoomIn();
        }

        if (triggerCollider.tag == "zoomOut")
        {
            Debug.Log("Send message to zoom Out method");
            cameraZoom.ZoomOut();
        }

        if (triggerCollider.tag == "guillotine")
        {
            Debug.Log("Guillotine triggered, activate flash");
            GameObject.Find("Gamestate").SendMessage("ActivateGuillotine", triggerCollider.transform);
        }

        if (triggerCollider.tag == "crush")
        {
            Debug.Log("Sphere triggered, activate flash");
            GameObject.Find("Gamestate").SendMessage("ActivateSphere", triggerCollider.transform);
        }

        if (triggerCollider.tag == "beast")
        {
            Debug.Log("Sphere triggered, activate flash");
            GameObject.Find("Gamestate").SendMessage("ActivateBeastDoor", triggerCollider.transform);
        }

        if (triggerCollider.tag == "spike")
        {
            Debug.Log("Spike triggered, activate flash");
            GameObject.Find("Gamestate").SendMessage("ActivateSpikes", triggerCollider.transform);
        }

        if (triggerCollider.tag == "floorButton")
        {
            Debug.Log("FloorButton touched, activating animation");
            Animator floorAnimator = GameObject.FindGameObjectWithTag("floorButton").GetComponent<Animator>();
            floorAnimator.SetBool("isPlaying", true);
        }

        if (triggerCollider.tag == "trueDoor")
        {
            Debug.Log("Nice, you won");
            this.GetComponent<CharacterMovement>().IsCharacterMoving = false;

            GameObject.Find("Gamestate").SendMessage("ChangeCurrentState", CurrentState.victory);
        }
    }

    void OnTriggerExit2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "jump" && isCharacterJumping) {
            ResetJumpTrigger();
        }

        if (triggerCollider.tag == "climb")
        {
            Debug.Log("Climbing finished");
            characterAction.isClimbing = false;

            triggerCollider.GetComponent<BoxCollider2D>().enabled = false;

            GameObject.Find("Gamestate").SendMessage("DeactivateClimb");
            isCharacterClimbing = false;
        }

        if (triggerCollider.tag == "fakeDoor") {
            Debug.Log("Game over, try again");
        }

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "crush")
        {
            Debug.Log("Sphere triggered, activate flash");
            GameObject.Find("Gamestate").SendMessage("ActivateSphere", other.transform);
        }
    }

    /// <summary>
    /// Resets jump trigger bool
    /// </summary>
    void ResetJumpTrigger() {
        isCharacterJumping = false;
        Debug.Log("Jump Trigger reset.");
    }
}

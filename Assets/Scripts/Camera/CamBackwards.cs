using UnityEngine;
using System.Collections;

public class CamBackwards : MonoBehaviour {

    bool canCameraMove;     //Can camera move?
    float cameraDelta;      //Delta of position x. Indicates where the camera should be
    float newDelta;

    void Start() {      
        cameraDelta = 1.80f;
    }

    /// <summary>
    /// Calculates where the camera should be after the character dies
    /// </summary>
    void CalculateDelta() {
        Transform character;

        character = GameObject.Find("character").transform;

        newDelta = character.position.x - cameraDelta;

        Debug.Log("NewDelta: " + newDelta);
    }

    /// <summary>
    /// Activates backward motion
    /// </summary>
    void ActivateBackwardMotion() {
        CalculateDelta();
        canCameraMove = true;

        this.GetComponent<CamFollow>().CanFollowCharacter = false;
    }

    // Update is called once per frame
    void Update () {
        if (canCameraMove) {
            MoveCameraBackwards();
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            ActivateBackwardMotion();
        }
	}

    /// <summary>
    /// Moves the camera backwards to show the level left behind.
    /// Allows player to see hints
    /// </summary>
    void MoveCameraBackwards() {
        if (this.transform.position.x > newDelta)
        {
            this.transform.position = new Vector3(this.transform.position.x - 0.02f,
                                                  this.transform.position.y,
                                                  this.transform.position.z);
        }
        else if (this.transform.position.x <= newDelta)
        {
            canCameraMove = false;
            GameObject.Find("Gamestate").SendMessage("ChangeCurrentState", CurrentState.showHints);
        }
    }
}

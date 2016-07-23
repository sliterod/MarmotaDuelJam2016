using UnityEngine;
using System.Collections;

public class Gamestate : MonoBehaviour {

    CurrentState currentState;
    CharacterMovement characterMovement;
    Rigidbody2D characterRigidbody;

    public int lives;

    // Use this for initialization
    void Start() {
        characterMovement = GameObject.Find("character").GetComponent<CharacterMovement>();
        characterRigidbody = GameObject.Find("character").GetComponent<Rigidbody2D>();

        ChangeCurrentState(CurrentState.ingame);
    }

    /// <summary>
    /// Checks if amount of lives is odd/even to decide if the message is to be shown or not
    /// </summary>
    void DisplayMessage() {

        int divResult;

        divResult = lives % 2;

        if (divResult == 0)
        {
            StartCoroutine(ShowMessage(3.0f));
        }
        else
        {
            StartCoroutine(ShowMessage(1.0f));
        }
    }

    /// <summary>
    /// Changes current game state and executes an action after that
    /// </summary>
    /// <param name="newState"></param>
    void ChangeCurrentState(CurrentState newState) {

        currentState = newState;
        Debug.Log("Changing state to: " + newState);

        switch (currentState) {

            case CurrentState.ingame:
                characterMovement.ActivateCharacterMovement(true);
                break;

            case CurrentState.message:
                DisplayMessage();
                break;

            case CurrentState.respawn:
                RespawnCharacter();
                break;

            case CurrentState.gameOver:
                break;
        }

    }

    /// <summary>
    /// Shows message after losing a life
    /// </summary>
    /// <param name="time">Waiting time</param>
    /// <returns>Respawn the character after time is out</returns>
    IEnumerator ShowMessage(float time) {

        //Stops character
        characterMovement.ActivateCharacterMovement(false);
        characterRigidbody.gravityScale = 0.0f;

        //Fades camera in
        GameObject.Find("UI").GetComponent<CamFade>().CameraFade(true);

        if (time > 1.0f)
        {
            GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(true);
        }

        //Shows message
        Debug.Log("Showing message");
        yield return new WaitForSeconds(time);

        //Changes state
        ChangeCurrentState(CurrentState.respawn);
    }

    /// <summary>
    /// Revives the character
    /// </summary>
    void RespawnCharacter() {
        //Respawn
        this.GetComponent<Respawn>().RespawnCharacter();
        characterRigidbody.gravityScale = 1.0f;

        //Change state
        ChangeCurrentState(CurrentState.ingame);

        //Fades camera out
        GameObject.Find("UI").GetComponent<CamFade>().CameraFade(false);
        GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(false);
    }
}

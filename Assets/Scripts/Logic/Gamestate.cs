using UnityEngine;
using System.Collections;

public class Gamestate : MonoBehaviour {

    CurrentState currentState;
    CharacterMovement characterMovement;
    Rigidbody2D characterRigidbody;
    Animator animator;
    GameObject character;

    public int lives;

    // Use this for initialization
    void Start() {

        character = GameObject.Find("character");

        characterMovement = character.GetComponent<CharacterMovement>();
        characterRigidbody = character.GetComponent<Rigidbody2D>();
        animator = character.GetComponent<Animator>();
        
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
            StartCoroutine(ShowMessage(3.5f));
        }
        else
        {
            StartCoroutine(ShowMessage(2.0f));
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

        //Reset jumper
        GameObject.Find("jumpEvent").transform.position = new Vector2(6.1f, -0.7f);

        //Reset Collider
        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.28f);
    }

    /// <summary>
    /// Executes changes when character falls on a pit
    /// </summary>
    void BottomPit() {
        GameObject.Find("Main Camera").GetComponent<CamFollow>().CanFollowCharacter = false;
        animator.SetTrigger("pitfall");

        StartCoroutine(BottomPitCoroutine());
    }

    IEnumerator BottomPitCoroutine() {
        yield return new WaitForSeconds(2.0f);
        //ChangeCurrentState(CurrentState.message);
    }

    /// <summary>
    /// Activates the guillotine effect
    /// </summary>
    void ActivateGuillotine(Transform guillotine) {

        characterMovement.IsCharacterMoving = false;
        
        //Animation start
        animator.SetTrigger("guillotine");
        animator.SetBool("isGuillotineTrap", false);

        //Flash
        GameObject.Find("Flash").SendMessage("ActivateFlash",true);

        StartCoroutine(ActivateGuillotineCoroutine(guillotine));
    }


    IEnumerator ActivateGuillotineCoroutine(Transform guillotine) {
        yield return new WaitForSeconds(0.1f);

        //Sprite
        guillotine.gameObject.SendMessage("DropGuillotine");

        //Character change
        character.transform.position = new Vector3( guillotine.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.10f);

        /*yield return new WaitForSeconds(2.0f);
        GameObject.Find("Flash").SendMessage("ActivateFlashMessage", true);*/
    }

    /// <summary>
    /// Activates sphere animation
    /// </summary>
    void ActivateSphere(Transform sphere) {
        characterMovement.IsCharacterMoving = false;
        
        //Animation start
        animator.SetTrigger("crush");

        //Flash
        GameObject.Find("Flash").SendMessage("ActivateFlash",true);

        StartCoroutine(ActivateSphereCoroutine(sphere));
    }


    IEnumerator ActivateSphereCoroutine(Transform sphere)
    {
        yield return new WaitForSeconds(0.05f);

        //Sprite
        sphere.gameObject.SendMessage("DropBall");

        //Change sprite
        character.GetComponent<SpriteRenderer>().enabled = false;
        character.transform.FindChild("crush").localScale = Vector2.one;

        //Character change
        character.transform.position = new Vector3( sphere.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.05f);

        /*yield return new WaitForSeconds(2.0f);
        GameObject.Find("Flash").SendMessage("ActivateFlashMessage", true);*/
    }

    /// <summary>
    /// Activates the spike effect
    /// </summary>
    void ActivateSpikes(Transform spike)
    {
        characterMovement.IsCharacterMoving = false;
        
        StartCoroutine(ActivateSpikesCoroutine(spike));
    }

    IEnumerator ActivateSpikesCoroutine(Transform spike)
    {
        //Sprite first change
        yield return new WaitForSeconds(0.05f);      

        //Animation start
        animator.SetTrigger("spike");

        //Flash
        GameObject.Find("Flash").SendMessage("ActivateFlash", true);
        spike.GetComponent<Animator>().SetTrigger("spike");

        yield return new WaitForSeconds(0.1f);
        
        //Character change
        character.transform.position = new Vector3( spike.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.05f);

        /*yield return new WaitForSeconds(2.0f);
        GameObject.Find("Flash").SendMessage("ActivateFlashMessage", true);*/
    }

    /// <summary>
    /// Activates climb animation
    /// </summary>
    void ActivateClimb() {
        characterMovement.IsCharacterMoving = false;
        characterRigidbody.isKinematic = true;

        animator.SetTrigger("climb");
    }

    /// <summary>
    /// Deactivates climb animation
    /// </summary>
    void DeactivateClimb() {
        StartCoroutine(DeactivateClimbCoroutine());
    }

    IEnumerator DeactivateClimbCoroutine() {
        animator.SetTrigger("climbFinished");
        yield return new WaitForSeconds(0.3f);

        characterMovement.IsCharacterMoving = true;
        characterRigidbody.isKinematic = false;

        
    }
}
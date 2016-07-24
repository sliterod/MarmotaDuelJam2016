using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamestate : MonoBehaviour {

    CurrentState currentState;
    CharacterMovement characterMovement;
    Rigidbody2D characterRigidbody;
    Animator animator;
    GameObject character;
    GameObject[] loadedRooms;
    Lives lifeController;
    SelectRooms selectRooms;
    SoundManager soundManager;

    int lives;

    // Use this for initialization
    void Start() {

        character = GameObject.Find("character");

        characterMovement = character.GetComponent<CharacterMovement>();
        characterRigidbody = character.GetComponent<Rigidbody2D>();
        animator = character.GetComponent<Animator>();
        lifeController = GameObject.Find("Loader").GetComponent<Lives>();
        lives = lifeController.LifeAmount;
        selectRooms = GameObject.Find("Loader").GetComponent<SelectRooms>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        ChangeCurrentState(CurrentState.ingame);

        if (selectRooms.CurrentDifficulty == Difficulty.easy ||
            selectRooms.CurrentDifficulty == Difficulty.normal)
        {
            if (PlayerPrefs.GetInt("messageShown", 0) == 0) {
                PlayerPrefs.SetInt("messageShown", 1);
                GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(true);
            }
        }
    }

    /// <summary>
    /// Displays hints on rooms after death
    /// </summary>
    void BroadcastHintDisplay(){
        Debug.Log("Broadcasting message");

        //Rooms
        loadedRooms = GameObject.FindGameObjectsWithTag("rooms");

        //Check difficulty
        if (selectRooms.CurrentDifficulty == Difficulty.easy || 
            selectRooms.CurrentDifficulty == Difficulty.normal)
        {
            foreach (GameObject go in loadedRooms)
            {
                go.SendMessage("NormalHints", SendMessageOptions.DontRequireReceiver);
            }
        }

        ReduceLives();
        ChangeCurrentState(CurrentState.message);
    }

    /// <summary>
    /// Checks if amount of lives is odd/even to decide if the message is to be shown or not
    /// </summary>
    void DisplayMessage() {

        int divResult;

        divResult = lives % 2;

        if (lives >= 0)
        {
            if (divResult == 0)
            {
                StartCoroutine(ShowMessage(3.5f));
            }
            else
            {
                StartCoroutine(ShowMessage(2.0f));
            }
        }
        else {
            ChangeCurrentState(CurrentState.gameOver);
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
                StartCoroutine(GameOver());
                break;

            case CurrentState.cameraBackwards:
                GameObject.FindGameObjectWithTag("MainCamera")
                    .SendMessage("ActivateBackwardMotion");
                break;

            case CurrentState.showHints:
                BroadcastHintDisplay();
                break;

            case CurrentState.victory:
                StartCoroutine(WinGame());
                break;
        }

    }

    /// <summary>
    /// Shows message after losing a life
    /// </summary>
    /// <param name="time">Waiting time</param>
    /// <returns>Respawn the character after time is out</returns>
    IEnumerator ShowMessage(float time) {

        yield return new WaitForSeconds(2.0f);

        //Stops character
        characterMovement.ActivateCharacterMovement(false);
        characterRigidbody.gravityScale = 0.0f;

        //Fades camera in
        GameObject.Find("UI").GetComponent<CamFade>().CameraFade(true);
        soundManager.PlayMessageSound();

        if (time > 1.0f)
        {
            //GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(true);

            switch (lives) {
                case 8:
                    GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(0);
                    break;

                case 6:
                    GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(1);
                    break;

                case 4:
                    GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(2);
                    break;

                case 2:
                    GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(3);
                    break;

                case 0:
                    GameObject.Find("UI").GetComponent<MessageUI>().ActivateMessage(5);
                    break;
            }

        }

        //Shows message
        Debug.Log("Showing message");
        yield return new WaitForSeconds(time);

        ReloadScene();
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

        //StartCoroutine(BottomPitCoroutine());
        //Go to camera
        ChangeCurrentState(CurrentState.cameraBackwards);
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
        soundManager.PlayGuillotine();

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

        //Go to camera
        ChangeCurrentState(CurrentState.cameraBackwards);
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
        soundManager.PlayRock();

        StartCoroutine(ActivateSphereCoroutine(sphere));
    }


    IEnumerator ActivateSphereCoroutine(Transform sphere)
    {
        yield return new WaitForSeconds(0.05f);

        //Sprite
        //sphere.gameObject.SendMessage("DropBall");

        //Change sprite
        character.GetComponent<SpriteRenderer>().enabled = false;
        character.transform.FindChild("crush").localScale = Vector2.one;

        //Character change
        character.transform.position = new Vector3( sphere.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.05f);

        //Go to camera
        ChangeCurrentState(CurrentState.cameraBackwards);
    }

    /// <summary>
    /// Activates the beast door
    /// </summary>
    /// <param name="door">Object with the door</param>
    void ActivateBeastDoor(Transform door) {
        characterMovement.IsCharacterMoving = false;

        //Flash
        GameObject.Find("Flash").SendMessage("ActivateFlash", true);
        soundManager.PlayDeath();

        StartCoroutine(ActivateDoorCoroutine(door));
    }

    IEnumerator ActivateDoorCoroutine(Transform door) {
        yield return new WaitForSeconds(0.05f);

        //Change sprite
        character.GetComponent<SpriteRenderer>().enabled = false;
        character.transform.FindChild("crush").localScale = Vector2.one;

        //Character change
        character.transform.position = new Vector3( door.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.05f);

        //Go to camera
        ChangeCurrentState(CurrentState.cameraBackwards);
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

        soundManager.PlayDeath();

        yield return new WaitForSeconds(0.1f);
        
        //Character change
        character.transform.position = new Vector3( spike.transform.position.x,
                                                    character.transform.position.y,
                                                    character.transform.position.z);

        character.GetComponent<BoxCollider2D>().size = new Vector2(0.21f, 0.05f);

        //Go to camera
        ChangeCurrentState(CurrentState.cameraBackwards);
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

    /// <summary>
    /// Starts Game Over coroutine
    /// </summary>
    /// <returns>Reloads the scene</returns>
    IEnumerator GameOver()
    {
        characterMovement.ActivateCharacterMovement(false);
        characterRigidbody.gravityScale = 0.0f;

        //Fades camera in
        GameObject.Find("UI").GetComponent<CamFade>().CameraFade(true);
        GameObject.Find("UI").GetComponent<MessageUI>().ActivateGameOverMessage();

        soundManager.PlayGameOver();

        yield return new WaitForSeconds(4.0f);
        LoadMainMenu();
    }

    /// <summary>
    /// Reloads this scene
    /// </summary>
    void ReloadScene() {
        Debug.Log("Reloading...");
        
        if (selectRooms.CurrentDifficulty == Difficulty.easy)
        {
            SceneManager.LoadScene("Easy1");
        }

        if (selectRooms.CurrentDifficulty == Difficulty.normal)
        {
            SceneManager.LoadScene("Normal1");
        }

        if (selectRooms.CurrentDifficulty == Difficulty.insane)
        {
            SceneManager.LoadScene("Insane");
        }
    }

    /// <summary>
    /// Loads main menu
    /// </summary>
    void LoadMainMenu() {
        Destroy(GameObject.Find("Loader"));
        PlayerPrefs.SetInt("messageShown", 0);
        SceneManager.LoadScene("menu");
    }

    /// <summary>
    /// Reduce the amount of lives
    /// </summary>
    void ReduceLives() {
        lifeController.LifeAmount -= 1;
        lives = lifeController.LifeAmount;
        Debug.Log("Remaining lives: " + lives);
    }

    /// <summary>
    /// Sets win game messages
    /// </summary>
    /// <returns></returns>
    IEnumerator WinGame() {

        yield return new WaitForSeconds(2.0f);

        Difficulty currentDiff = selectRooms.CurrentDifficulty;

        //Fades camera in
        GameObject.Find("UI").GetComponent<CamFade>().CameraFade(true);
        GameObject.Find("UI").GetComponent<MessageUI>().ActivateWinMessage(currentDiff);

        yield return new WaitForSeconds(8.0f);
        LoadMainMenu();
    }
}
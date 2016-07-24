using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    public Sprite[] flashObjects;       //Flash sprites
    SpriteRenderer spriteRenderer;      //Sprite renderer object

	// Use this for initialization
	void Start () {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

    /// <summary>
    /// Activates a flash effect
    /// </summary>
    void ActivateFlash() {
        this.transform.localScale = Vector3.one;
        StartCoroutine(ExecuteFlash(false));
    }

    /// <summary>
    /// Activates the flash effect for the message
    /// </summary>
    void ActivateFlashMessage() {
        this.transform.localScale = Vector3.one;
        StartCoroutine(ExecuteFlash(true));
    }

    IEnumerator ExecuteFlash(bool isGameOverFlash) {

        Debug.Log("Flash");

        yield return new WaitForSeconds(0.05f);
        spriteRenderer.sprite = flashObjects[0];

        yield return new WaitForSeconds(0.05f);
        spriteRenderer.sprite = flashObjects[1];

        yield return new WaitForSeconds(0.05f);
        spriteRenderer.sprite = flashObjects[2];

        yield return new WaitForSeconds(0.05f);
        this.transform.localScale = Vector3.zero;

        if (isGameOverFlash) {
            GameObject.Find("Gamestate").SendMessage("ChangeCurrentState",CurrentState.message);
        }
    }
}

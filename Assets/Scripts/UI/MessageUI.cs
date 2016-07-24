using UnityEngine;
using System.Collections;

public class MessageUI : MonoBehaviour {

    public GameObject message;

    /// <summary>
    /// Activates message object
    /// </summary>
    /// <param name="state">True to activate, false otherwise</param>
    public void ActivateMessage(bool state) {
        message.SetActive(state);
    }

    /// <summary>
    /// Activates game over message
    /// </summary>
    public void ActivateGameOverMessage() {
        Debug.Log("Game over message");
    }

    public void SetMessage() {

    }
}

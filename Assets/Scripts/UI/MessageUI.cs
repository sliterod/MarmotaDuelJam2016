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

    
    public void SetMessage() {

    }
}

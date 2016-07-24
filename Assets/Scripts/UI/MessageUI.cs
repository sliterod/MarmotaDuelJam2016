using UnityEngine;
using System.Collections;

public class MessageUI : MonoBehaviour {

    public GameObject message;
    public GameObject[] liveMessages;
    public GameObject gameOverMessage;
    public GameObject[] victoryMessage;

    /// <summary>
    /// Activates message object
    /// </summary>
    /// <param name="state">True to activate, false otherwise</param>
    public void ActivateMessage(bool state) {
        message.SetActive(state);
        StartCoroutine(MessageActivated());
    }

    IEnumerator MessageActivated() {
        yield return new WaitForSeconds (1.5f);
        message.SetActive(false);
    }

    /// <summary>
    /// Activates an specific message
    /// </summary>
    /// <param name="position"></param>
    public void ActivateMessage(int position)
    {
        liveMessages[position].SetActive(true);
    }

    /// <summary>
    /// Activates game over message
    /// </summary>
    public void ActivateGameOverMessage() {
        Debug.Log("Game over message");
        gameOverMessage.SetActive(true);
    }

    /// <summary>
    /// Activates Win Message
    /// </summary>
    /// <param name="diff">Current difficulty</param>
    public void ActivateWinMessage(Difficulty diff) {
        Debug.Log("Win message");

        if (diff == Difficulty.easy) {
            victoryMessage[0].SetActive(true);
        }

        if (diff == Difficulty.normal)
        {
            victoryMessage[1].SetActive(true);
        }

        if (diff == Difficulty.insane)
        {
            victoryMessage[2].SetActive(true);
        }
    }
}

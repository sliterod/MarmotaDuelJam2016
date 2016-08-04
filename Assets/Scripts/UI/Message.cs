using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

    string[] messages;

    public string[] Messages
    {
        get
        {
            return messages;
        }

        set
        {
            messages = value;
        }
    }

    /// <summary>
    /// Class constructor for Message
    /// </summary>
    /// <param name="size">Array size</param>
    public Message(int size) {
        messages = new string[size];
    }
}

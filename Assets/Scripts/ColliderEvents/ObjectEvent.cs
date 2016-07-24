using UnityEngine;
using System.Collections;

public class ObjectEvent : MonoBehaviour
{
    public string MessageName;
    public GameObject target;


    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        target.SendMessage(MessageName, SendMessageOptions.DontRequireReceiver);
    }
}

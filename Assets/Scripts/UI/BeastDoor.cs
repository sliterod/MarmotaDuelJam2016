using UnityEngine;
using System.Collections;

public class BeastDoor : MonoBehaviour {

    public GameObject hint;

    /// <summary>
    /// Activates the hint to show what to do with this hazard
    /// </summary>
    public void ActivateHint() {
        hint.SetActive(true);
    }
}

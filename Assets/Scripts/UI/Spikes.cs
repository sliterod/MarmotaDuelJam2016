using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    /// <summary>
    /// Disables this hazard
    /// </summary>
    void DisableHazard()
    {
        Debug.Log("Hazard disabled");
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}

using UnityEngine;
using System.Collections;

public class ShowLadder : MonoBehaviour {

    public GameObject ladder;

    /// <summary>
    /// Disables this hazard or in this case activate it
    /// </summary>
    void DisableHazard()
    {
        ladder.SetActive(true);
    }
}

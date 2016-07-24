using UnityEngine;
using System.Collections;

public class RockTrapActivator : MonoBehaviour {

    /// <summary>
    /// Disables this hazard or in this case activate it
    /// </summary>
    void DisableHazard()
    {
        BroadcastMessage("DropBall");
    }
}

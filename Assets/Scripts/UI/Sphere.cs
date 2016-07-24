using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

    public Transform ball;

    /// <summary>
    /// Drops the ball on the player
    /// </summary>
    void DropBall() {
        ball.localPosition = new Vector2(0.0f, -0.59f);
    }

    void ResetSphere() {
        ball.localPosition = new Vector2(0.0f, 0.0f);
    }

    /// <summary>
    /// Disables this hazard
    /// </summary>
    void DisableHazard()
    {
        Debug.Log("Hazard disabled");
        ball.localPosition = new Vector2(0.0f, 1.20f);
    }
}

using UnityEngine;
using System.Collections;

public class MoveFloorDown : MonoBehaviour {

    bool isMoving = false;
    public float targetY = 0.0f;
    /// <summary>
    /// Disables this hazard or in this case activate it
    /// </summary>
    void DisableHazard()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(-Vector3.up * Time.deltaTime * 2.0f);
            if (transform.localPosition.y <= targetY)
            {
                isMoving = false;
                transform.localPosition = new Vector3(transform.localPosition.x, targetY, 0);
            }
        }

    }
}

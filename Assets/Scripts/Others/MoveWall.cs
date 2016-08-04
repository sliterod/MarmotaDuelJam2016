using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour {

    bool isMoving = false;
    float targetY = 0.0f;
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
            transform.Translate(Vector3.up * Time.deltaTime*1.2f);
            if(transform.localPosition.y >= 0)
            {
                isMoving = false;
            }
        }
        
    }
}

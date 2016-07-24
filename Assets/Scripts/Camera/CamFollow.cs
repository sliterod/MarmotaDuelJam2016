using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    float cameraXposAddedValue;
    public Transform character;
    bool canFollowCharacter;

    public float CameraXposAddedValue
    {
        get
        {
            return cameraXposAddedValue;
        }

        set
        {
            cameraXposAddedValue = value;
        }
    }

    public bool CanFollowCharacter
    {
        get
        {
            return canFollowCharacter;
        }

        set
        {
            canFollowCharacter = value;
        }
    }

    void Awake() {
        canFollowCharacter = true;
    }

    // Update is called once per frame
    void Update () {
        if (canFollowCharacter)
        {
            FollowCharacter(cameraXposAddedValue);
        }
    }

    /// <summary>
    /// Follows the character movement
    /// </summary>
    /// <param name="addedXvalue">Amount of value to be added to current camera position</param>
    void FollowCharacter(float camPosX) {

        float addedPosX = 0.0f;

        if (camPosX <= 0.0f)
        {
            addedPosX = 1.5f;
        }
        else {
            addedPosX = camPosX;
        }

        this.transform.position = new Vector3(  character.position.x + addedPosX,
                                                character.position.y,
                                                -10.0f);
    }
}

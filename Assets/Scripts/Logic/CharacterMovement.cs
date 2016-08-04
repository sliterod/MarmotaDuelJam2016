using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float moveSpeed;     //Movement speed
    bool isCharacterMoving;     //Is character moving?

    public bool IsCharacterMoving
    {
        get
        {
            return isCharacterMoving;
        }

        set
        {
            isCharacterMoving = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCharacterMoving)
        {
            MoveCharacter();
        }
    }

    /// <summary>
    /// Moves character from point A to B with a fixed speed
    /// </summary>
    void MoveCharacter()
    {
        this.transform.position = new Vector3(this.transform.position.x + (moveSpeed * Time.deltaTime),
                                                this.transform.position.y,
                                                this.transform.position.z);
    }

    /// <summary>
    /// Resumes/stops character movement
    /// </summary>
    /// <param name="state">True for moving, false for stopping</param>
    public void ActivateCharacterMovement(bool state) {
        IsCharacterMoving = state;
    }
}

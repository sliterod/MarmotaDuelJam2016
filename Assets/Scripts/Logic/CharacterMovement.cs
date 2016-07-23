using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float moveSpeed;     //Movement speed

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
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
}

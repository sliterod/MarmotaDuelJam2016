using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public Transform character;
    Vector3 characterInitialPosition;

	void Awake () {
        characterInitialPosition = character.transform.position;
	}

    /// <summary>
    /// Sets the character on the initial position
    /// </summary>
    void RespawnCharacter() {
        character.position = characterInitialPosition;
    }
}

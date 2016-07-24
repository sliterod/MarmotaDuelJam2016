using UnityEngine;
using System.Collections;

public class CameraStop : MonoBehaviour {

    public CamFollow camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        camera.CanFollowCharacter = false;
    }
}

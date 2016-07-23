﻿using UnityEngine;
using System.Collections;

public class ColliderEvents : MonoBehaviour {

    CharacterAction characterAction;
    CamZoom cameraZoom;

    bool isCharacterJumping;

    void Start() {
        characterAction = this.GetComponent<CharacterAction>();
        cameraZoom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamZoom>();
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {
        
        if (triggerCollider.tag == "jump" && !isCharacterJumping)
        {
            Debug.Log("Send message to jump method");
            characterAction.isJumping = true;
            isCharacterJumping = true;
        }

        if (triggerCollider.tag == "hazard")
        {
            Debug.Log("Hazard! Restarting game");
            GameObject.Find("Gamestate").SendMessage("RespawnCharacter");
        }

        if (triggerCollider.tag == "climb")
        {
            Debug.Log("Send message to climb method");
        }

        if (triggerCollider.tag == "zoomIn")
        {
            Debug.Log("Send message to zoom In method");
            cameraZoom.ZoomIn();
        }

        if (triggerCollider.tag == "zoomOut")
        {
            Debug.Log("Send message to zoom Out method");
            cameraZoom.ZoomOut();
        }
    }

    void OnTriggerExit2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "jump" && isCharacterJumping) {
            ResetJumpTrigger();
        }
    }

    /// <summary>
    /// Resets jump trigger bool
    /// </summary>
    void ResetJumpTrigger() {
        isCharacterJumping = false;
        Debug.Log("Jump Trigger reset.");
    }
}
using UnityEngine;
using System.Collections;

public class ClickEvents : MonoBehaviour {
    void OnMouseDown() {      
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Click on element");

            Animator animator;
            animator = this.GetComponent<Animator>();

            animator.SetBool("isPlaying", true);
        }
    }
}

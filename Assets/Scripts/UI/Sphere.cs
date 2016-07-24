using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

    public GameObject ball;
    public GameObject particles;
    public GameObject sprite;

    /// <summary>
    /// Drops the ball on the player
    /// </summary>
    void DropBall() {
        this.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void ResetSphere() {
        
    }

    /// <summary>
    /// Disables this hazard
    /// </summary>
    void DisableHazard()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        sprite.SetActive(false);
        particles.SetActive(true);
    }

}

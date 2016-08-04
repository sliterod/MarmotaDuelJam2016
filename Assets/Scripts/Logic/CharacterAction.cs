using UnityEngine;
using System.Collections;

public class CharacterAction : MonoBehaviour {

    public float jumpSpeed;     //Jumping speed
    public float jumpMaxY;      //Maximum y distance
    public float climbSpeed;    //Climbing speed (ladder only)
    public bool isJumping;      //Is character jumping?
    public bool isClimbing;     //Is character climbing?

    float initialPositionY;     //Character initial position on y-axis

    void Start() {
        initialPositionY = this.transform.position.y;
    }

	// Update is called once per frame
	void Update () {
        if (isJumping) {
            Jump();
        }

        if (isClimbing) {
            Climb();
        }
	}

    /// <summary>
    /// Makes the character jump an obstacle
    /// </summary>
    void Jump() {

        float yPosition = this.transform.position.y;

        if (yPosition <= jumpMaxY)
        {
            this.transform.position = new Vector3(this.transform.position.x + 0.035f,
                                                    this.transform.position.y + jumpSpeed,
                                                    this.transform.position.z);

            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else if (yPosition > jumpMaxY)
        {
            isJumping = false;
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    /// <summary>
    /// Makes the character climb
    /// </summary>
    void Climb() {
        if (isJumping)
        {
            isJumping = false;
            
        }
        
        float yPosition = this.transform.position.y;

        this.transform.position = new Vector3(  this.transform.position.x,
                                                this.transform.position.y + climbSpeed,
                                                this.transform.position.z);
    }
}

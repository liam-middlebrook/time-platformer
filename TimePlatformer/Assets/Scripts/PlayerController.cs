using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The Speed of the Player's Horizontal Movement
    /// </summary>
    public float playerSpeed;

    /// <summary>
    /// The jumping force of the player
    /// </summary>

    public float jumpHeight;
    /// <summary>
    /// Whether or not the player has the ability to jump
    /// </summary>
    private bool canJump = true;

	/// <summary>
	/// The booloean used to guage the players direction.
	/// </summary>
	private bool faceRight = true;

    /// <summary>
    /// The temporary velocity of the player before application to the rigidbody
    /// </summary>
    private Vector2 vel = Vector2.zero;

	/// <summary>
	/// This is the local booleon used to track if the player is moving based on whether or not they have hit movement keys
	/// </summary>
	private bool moving= false;
    
    // Update since time and physics sensitive
    void Update ()
    {
        vel = Vector2.zero;
		moving = false;

        // Move Left
        if (Input.GetKey(KeyCode.A)
            || Input.GetAxis("Horizontal") < -0.2f
            )
        {
            vel += new Vector2(-1.0f, 0.0f);
			// trigger the booleon for the movement animation
			moving=true;
			if(faceRight) Flip ();
        }

        // Move Right
        if (Input.GetKey(KeyCode.D)
            || Input.GetAxis("Horizontal") > 0.2f
            )
        {
            vel += new Vector2(1.0f, 0.0f);
			moving=true;
			if(!faceRight) Flip ();
        }

        // Jump
        if (Input.GetKey(KeyCode.W)
            || Input.GetButton("joystick 1 button 0") //shield
            || Input.GetButton("joystick 1 button 7") //pc
            )
        {
            if(canJump)
            {
                canJump = false;
                vel += new Vector2(0.0f, jumpHeight);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetButtonDown("joystick 1 button 2") //shield
            || Input.GetButtonDown("joystick 1 button 9") //pc
            )
        {
            TimeController.Instance.ToggleTime();
        }

		// trigger the booleon for the movement animation using our local boolean
		this.GetComponent<Animator>().SetBool("moving", moving);

        // trigger the booleon for the movement animation using our local boolean
        this.GetComponent<Animator>().SetBool("jumping", !canJump);

        // Apply force to rigidbody
        this.GetComponent<Rigidbody2D>().AddForce(playerSpeed * vel);
    }

	//Flips the booleon for the player direction for next time, then mirrors the player along the Y axis.
	private void Flip()
	{
		faceRight= !faceRight;
		Vector3 revScale = transform.localScale;
		revScale.x *= -1;
		transform.localScale = revScale;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}

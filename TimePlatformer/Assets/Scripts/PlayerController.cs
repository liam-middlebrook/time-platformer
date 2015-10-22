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

	/// <summary>
	/// The float that will givew the distance we check using a raycast for grounded detection
	/// </summary>
	private float groundDist;

	/// <summary>
	/// This booleon basically checks to see if the player has already initiated a jump one frame ago. If they have, we don't allow the system to check if we can add more jump force
	/// </summary>
	private bool aired;

	// A start function so we can set ground distance and give aired an initial value.
	void Start()
	{
		groundDist = GetComponent<BoxCollider2D> ().bounds.extents.y;
		aired = false;
	}
    
    // Update since time and physics sensitive
    void Update ()
    {
        vel = Vector2.zero;
		moving = false;

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            vel += new Vector2(-1.0f, 0.0f);
			// trigger the booleon for the movement animation
			moving=true;
			if(faceRight) Flip ();
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            vel += new Vector2(1.0f, 0.0f);
			moving=true;
			if(!faceRight) Flip ();
        }

        // Jump
        if (Input.GetKey(KeyCode.W))
        {
	            if(IsGrounded())
	            {
					//making sure they haven't already started a jump last frame and happen to still be close to the block
					if(!aired){
						aired=true;
		                vel += new Vector2(0.0f, jumpHeight);
					}
				}else{
				aired=false;
			}
			}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeController.Instance.ToggleTime();
        }

		// trigger the booleon for the movement animation using our local boolean
		this.GetComponent<Animator>().SetBool("moving", moving);

        // Apply force to rigidbody
        this.GetComponent<Rigidbody2D>().AddForce(playerSpeed * vel);

    }

	private bool IsGrounded(){
		RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position, Vector2.down, groundDist+.02f);
		for (int i=0; i<hit.Length; i++) {
			if (hit [i].transform.gameObject.tag != "Player") {
				return true;
			} 
		} 
		return false;
	}

	//Flips the booleon for the player direction for next time, then mirrors the player along the Y axis.
	private void Flip()
	{
		faceRight= !faceRight;
		Vector3 revScale = transform.localScale;
		revScale.x *= -1;
		transform.localScale = revScale;
	}
}

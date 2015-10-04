using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// The Speed of the Player's Horizontal Movement
    /// </summary>
    public float playerSpeed = 15.0f;

    /// <summary>
    /// The time in seconds for the player between jumps
    /// </summary>
    public float jumpCooldown = 1.8f;

    /// <summary>
    /// The jumping force of the player
    /// </summary>

    public float jumpHeight = 25.0f;
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
    
    // Update since time and physics sensitive
    void Update ()
    {
        vel = Vector2.zero;

        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            vel += new Vector2(-1.0f, 0.0f);
			if(faceRight){
				faceRight= !faceRight;

				Vector3 revScale = transform.localScale;
				revScale.x *= -1;
				transform.localScale = revScale;
			}
        }

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            vel += new Vector2(1.0f, 0.0f);
			if(!faceRight){
				faceRight= !faceRight;
				
				Vector3 revScale = transform.localScale;
				revScale.x *= -1;
				transform.localScale = revScale;
			}
        }

        // Jump
        if (Input.GetKey(KeyCode.W))
        {
            if(canJump)
            {
                canJump = false;
                StartCoroutine("Jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeController.Instance.ToggleTime();
        } 

        // Apply force to rigidbody
        this.GetComponent<Rigidbody2D>().AddForce(playerSpeed * vel);
    }
    
    IEnumerator Jump()
    {
        vel += new Vector2(0.0f, jumpHeight);
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 24.0f;
    public float jumpCooldown = 1.8f;

    private bool canJump = true;
    private Vector2 vel = Vector2.zero;

    // Update is called once per frame
    void FixedUpdate ()
    {
        vel = Vector2.zero;
        if (Input.GetKey("a"))
        {
            vel += new Vector2(-1.0f, 0.0f);
        }

        if (Input.GetKey("d"))
        {
            vel += new Vector2(1.0f, 0.0f);
        }

        if (Input.GetKey("w"))
        {
            if(canJump)
            {
                canJump = false;
                StartCoroutine("Jump");
            }
        }

        this.GetComponent<Rigidbody2D>().AddForce(playerSpeed * vel);
    }

    IEnumerator Jump()
    {
        vel += new Vector2(0.0f, 25.0f);
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}

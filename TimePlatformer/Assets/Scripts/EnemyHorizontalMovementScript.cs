using UnityEngine;
using System.Collections;

public class EnemyHorizontalMovementScript : MonoBehaviour {

    /// <summary>
    /// Direction the enemy faces, based on 1 and -1 to flip the enemy and his movement direction
    /// </summary>
    public int direction;

    /// <summary>
    /// The speed the enemy moves at within the range
    /// </summary>
    public float walkSpeed;

    /// <summary>
    /// The max distance from the starting vector that the enemy can deviate from
    /// </summary>
    public float maxRange;

    /// <summary>
    /// The position the enemy was at before movement begins
    /// </summary>
    private Vector2 startPosition;

    /// <summary>
    /// The vector that moves the enemy, may later be edited to suit flying enemies
    /// </summary>
    private Vector2 walkingVector;

	// Use this for initialization
	void Start () 
	{
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        Walk();
	}

    /// <summary>
    /// Calculates the movement through vectors and translations
    /// </summary>
    void Walk()
    {
        if (Vector2.Distance(transform.position, startPosition) > maxRange / 10.0f)
        {
            direction *= -1;
            Vector2 revScale = transform.localScale;
            revScale.x *= -1.0f;
            transform.localScale = revScale;
			transform.Translate(new Vector2((direction * (walkSpeed + 1.1f)) * Time.deltaTime, 0.0f));
        }

        walkingVector = new Vector2(direction * walkSpeed, 0.0f);
        transform.Translate(walkingVector * Time.deltaTime);
    }
}

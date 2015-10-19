using UnityEngine;
using System.Collections;

public class EnemyHorizontalMovementScript : MonoBehaviour {

<<<<<<< HEAD
	/// <summary>
	/// Used to change the movement based on time of day
	/// </summary>
	public TimeOfDay ActiveWhen;

	/// <summary>
	/// Determines if the enemy is active all the time
	/// </summary>
	public bool ActiveAllTheTime;

	/// <summary>
	/// The direction as an integer to change the direction of the enemy
	/// </summary>
    public int direction;

	/// <summary>
	/// The float value that determines the speed the enemy moves to reach the max range
	/// </summary>
    public float walkSpeed;

	/// <summary>
	/// The range the enemy will move in between
	/// </summary>
    public float maxRange;

	/// <summary>
	/// The position the enemy started at
	/// </summary>
    private Vector2 startPosition;

	/// <summary>
	/// The vector used for the enemy's translation
	/// </summary>
    private Vector2 walkingVector;

	/// <summary>
	/// Determines if the enemy is moving
	/// </summary>
	private bool isWalking;

	private bool outOfRange;

=======
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

>>>>>>> c320af5ec820fec6ba6b66063a076083df7ce2c5
	// Use this for initialization
	void Start () 
	{
        startPosition = transform.position;
<<<<<<< HEAD
		outOfRange = false;
=======
>>>>>>> c320af5ec820fec6ba6b66063a076083df7ce2c5
	}
	
	// Update is called once per frame
	void Update () 
	{
<<<<<<< HEAD
		if (isWalking || ActiveAllTheTime) 
		{
			Walk ();
		}
		
		// Listen to the time changed event
		TimeController.Instance.TimeChanged += TimeChanged;
		
		// Set the intial state of the object based on what time the
		// level is starting off as
		
		TimeChanged(TimeController.Instance.CurrentTime);
	}

    void Walk()
    {
        if (Vector2.Distance (transform.position, startPosition) >= maxRange / 10.0f && !outOfRange) {
			outOfRange = true;
			direction *= -1;
			//transform.Translate(walkingVector * direction * Time.deltaTime);
			Vector2 revScale = transform.localScale;
			revScale.x *= -1.0f;
			transform.localScale = revScale;
		} 
		else 
		{
			outOfRange = false;
		}
		
        walkingVector = new Vector2(direction * walkSpeed, 0.0f);
        transform.Translate(walkingVector * Time.deltaTime);
    }

	// Checks if the change of time will stop the enemy
	void TimeChanged(TimeOfDay newTime)
	{
		isWalking = (newTime == ActiveWhen);
	}

	void OnDestroy()
	{
		TimeController.Instance.TimeChanged -= TimeChanged;
	}
=======
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
>>>>>>> c320af5ec820fec6ba6b66063a076083df7ce2c5
}

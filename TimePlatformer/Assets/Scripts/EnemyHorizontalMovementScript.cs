using UnityEngine;
using System.Collections;

public class EnemyHorizontalMovementScript : MonoBehaviour {

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

	// Use this for initialization
	void Start () 
	{
        startPosition = transform.position;
		outOfRange = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
}

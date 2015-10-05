using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

	/// <summary>
	/// The force applied by the wind
	/// </summary>
	public float force;

	// What TimeOfDay is this object active during?
	public TimeOfDay ForceRightWhen;

	//The vector for the force being applied by the wind.
	private Vector2 forceVec;

	// Use this for initialization
	void Start () {
		// Listen to the time changed event
		TimeController.Instance.TimeChanged += TimeChanged;
		
		// Set the intial state of the object based on what time the
		// level is starting off as
		TimeChanged(TimeController.Instance.CurrentTime);
	}

	// Handle switching for the time of day
	void TimeChanged(TimeOfDay newTime)
	{
		if (newTime == ForceRightWhen) {
			forceVec= new Vector2(1*force,0);
		} else {
			forceVec= new Vector2(-1*force,0);
		}
	}

	void OnTriggerStay2D (Collider2D col){

		col.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVec);
	}
}

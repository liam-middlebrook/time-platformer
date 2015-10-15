using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

	/// <summary>
	/// The force applied by the wind
	/// </summary>
	public Vector2 force;

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
		Flip ();
		if (newTime == ForceRightWhen) {
			forceVec= force;
		} else {
			forceVec= -force;
		}
	}

	void OnTriggerStay2D (Collider2D col){
		col.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVec);
	}

	//Mirrors the wind along the Y axis.
	private void Flip()
	{
		Vector3 revScale = transform.localScale;
		revScale.x *= -1;
		transform.localScale = revScale;
	}

	void OnDestroy()
	{
		TimeController.Instance.TimeChanged -= TimeChanged;
	}
}

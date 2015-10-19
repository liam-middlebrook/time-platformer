using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {

	/// <summary>
	/// The respawn location for the player after death.
	/// </summary>
	public Vector3 respawnLoc;

	/// <summary>
	/// Checks for collision (with the player) and then resets the player back to a respanwn location.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D (Collision2D col){
		col.gameObject.transform.position = respawnLoc;
	}
}

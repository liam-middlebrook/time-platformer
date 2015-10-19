using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	/// <summary>
	/// The respawn location for the player after death.
	/// </summary>
	private GameObject respawn;

	/// <summary>
	/// Checks for collision (with the player) and then resets the player back to a respanwn location.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D (Collision2D col){
		respawn = GameObject.FindGameObjectWithTag ("Spawner");
		col.transform.position = respawn.transform.position;
	}
}

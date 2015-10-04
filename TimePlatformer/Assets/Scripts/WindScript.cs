using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

	/// <summary>
	/// the variable, which should be set externally, that denotes whether this is day wind or not.
	/// </summary>
	public bool day;

	/// <summary>
	/// The force.
	/// </summary>
	public float force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col){

		if (day) {
			Vector2 moveVec = new Vector2(12,0);
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(moveVec);
		} else {
			Vector2 moveVec = new Vector2(-12,0);
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(moveVec);
		}
	}
}

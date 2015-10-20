using UnityEngine;
using System.Collections;

public class HypnoBounceScript : MonoBehaviour {

	/// <summary>
	/// The amount of bounce the character will go
	/// </summary>
    public float bounceAmount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (bounceAmount * Vector2.up);
		}
    }
}

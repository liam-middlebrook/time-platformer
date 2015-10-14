using UnityEngine;
using System.Collections;

public class HypnoBounceScript : MonoBehaviour {

    /// <summary>
    /// The Amount the character bounces upon landing on the enemy
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
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceAmount * Vector2.up);
    }
}

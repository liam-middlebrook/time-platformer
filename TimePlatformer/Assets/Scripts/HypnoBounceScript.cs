using UnityEngine;
using System.Collections;

public class HypnoBounceScript : MonoBehaviour {

    public float bounceAmount;

    private Vector2 bounceForceVector;

	// Use this for initialization
	void Start () {
        bounceForceVector = new Vector2(0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceAmount * bounceForceVector);
    }
}

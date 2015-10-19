using UnityEngine;
using System.Collections;

public class HypnoBounceScript : MonoBehaviour {

<<<<<<< HEAD
	/// <summary>
	/// The amount of bounce the character will go
	/// </summary>
    public float bounceAmount;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
=======
    /// <summary>
    /// The Amount the character bounces upon landing on the enemy
    /// </summary>
    public float bounceAmount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
>>>>>>> c320af5ec820fec6ba6b66063a076083df7ce2c5
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceAmount * Vector2.up);
    }
}

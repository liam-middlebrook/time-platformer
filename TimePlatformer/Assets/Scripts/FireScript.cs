using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		col.gameObject.transform.position = new Vector3 (0f, 1.5f, 0f);
	}
}

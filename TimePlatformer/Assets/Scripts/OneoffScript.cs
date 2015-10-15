using UnityEngine;
using System.Collections;

public class OneoffScript : MonoBehaviour {
	public GameObject text;
	private MeshRenderer _renderer;

	// Use this for initialization
	void Start () {
		text.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	void OnTriggerEnter2D (Collider2D col){
		text.GetComponent<MeshRenderer> ().enabled = true;
	}
}

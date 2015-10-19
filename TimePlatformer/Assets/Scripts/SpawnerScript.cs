using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
		Instantiate (Player);
		Player.transform.position = this.transform.position;
	}
}

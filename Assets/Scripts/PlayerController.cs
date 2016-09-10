using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = gameObject;
	}

	// FixedUpdate called once per physics tick
	void FixedUpdate() {
		// Movement
		var x = Input.GetAxis("Horizontal") * Time.deltaTime;
		var z = Input.GetAxis("Vertical") * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

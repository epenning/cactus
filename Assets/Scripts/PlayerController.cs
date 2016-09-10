using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	public GameObject rbody;

	public float speed = 0f;

	// Use this for initialization
	void Start () {
		player = gameObject;
		rbody = GetComponent<Rigidbody2D>();
	}

	// FixedUpdate called once per physics tick
	void FixedUpdate() {
		// Movement
		var vx = Input.GetAxis("Horizontal") * speed;
		var vy = Input.GetAxis("Vertical") * speed;

		rbody.velocity = new Vector2 (vx, vy);
	}

	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D rbody;

	public float speed = 0f;

	// Use this for initialization
	void Start () {
		player = gameObject;
		rbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		// Movement
		var vx = Input.GetAxis("Horizontal");
		var vy = Input.GetAxis("Vertical");
		var velocity = new Vector2 (vx, vy);
		if (velocity.magnitude > 1)
			velocity.Normalize ();
		
		rbody.velocity = velocity * speed;
	}

	void ExtendSpikes () {
		foreach (Transform child in transform) {
			var sprite = child.Find ("Sprite");
		}
	}
}

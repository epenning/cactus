using UnityEngine;
using System.Collections;

public class PlayerController : CactusController {

	public float speed = 0f;

	// Update is called once per frame
	void Update () {
		// Movement
		var vx = Input.GetAxis("Horizontal");
		var vy = Input.GetAxis("Vertical");
		var velocity = new Vector2 (vx, vy);
		if (velocity.magnitude > 1)
			velocity.Normalize ();
		
		rbody.velocity = velocity * speed;

		// Spike Extending
		if (Input.GetKeyDown ("space")) {
			if (!spikesExtended)
				ExtendSpikes ();
		}
	}
}

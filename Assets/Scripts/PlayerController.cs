using UnityEngine;
using System.Collections;

public class PlayerController : CactusController {

	public float speed = 0f;

	public bool powerup = false;
	public Vector3 direction;

	public float projectileSpeed = 10f;

	public Rigidbody2D rbody;

	// Use this for initialization
	protected void Start () {
		rbody = GetComponent<Rigidbody2D>();
		direction =new Vector3 (0f, 0f, 0f);

		base.Start ();
	}

	// Update is called once per frame
	void Update () {
		// Movement
		var vx = Input.GetAxis("Horizontal");
		var vy = Input.GetAxis("Vertical");
		var velocity = new Vector2 (vx, vy);
		if (velocity.magnitude > 1) {
			velocity.Normalize ();
		}
		if (velocity.magnitude > 0.1) {
			direction = new Vector3(velocity.normalized.x, velocity.normalized.y);
		}

		rbody.velocity = velocity * speed;
			

		// Spike Extending
		if (Input.GetKeyDown ("space")) {
			if (!spikesExtended)
				ExtendSpikes ();
		}

		// Using Powerup
		if (Input.GetKeyDown("e")) {
			if (powerup) {
				powerup = false;

				// activate powerup
				ShootProjectile ();
			}
		}
	}

	void ShootProjectile() {
		powerup = false;
		GameObject projectile = (GameObject) Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(Vector3.forward, direction));
		projectile.GetComponent<Rigidbody2D> ().velocity = direction * projectileSpeed;
	}
}

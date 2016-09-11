using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerObjectController : MonoBehaviour {

    public float speed = 0f;
    public Rigidbody2D rbody;

	public bool powerup = false;
	public Vector3 direction;

	public float projectileSpeed = 10f;

    public int playerNum;

    public List<GameObject> cactiBalls;

	public GameObject cactiBallPrefab;
	public GameObject projectilePrefab;

    public Vector3 startPos;

    public string hAxis;
    public string vAxis;

	public string spikeKey;

    public int size;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        Spawn();
    }

    void Spawn()
    {
		if (transform.childCount > 0)
			Debug.LogError ("RESPAWN WHEN THERE WAS A CACTUS!");

        cactiBalls = new List<GameObject>();
        transform.position = startPos;
        GameObject newCactiBall = GameObject.Instantiate(cactiBallPrefab);
        newCactiBall.transform.parent = transform;
        newCactiBall.transform.localPosition = Vector3.zero;
        newCactiBall.GetComponent<CactusController>().ownerNum = playerNum;
        cactiBalls.Add(newCactiBall);
        size = 1;
    }

	public void Kill() {
		Spawn ();
	}

    // Update is called once per frame
    void Update () {
        //bool 
        // Movement
        var vx = Input.GetAxis(hAxis);
        // We don't know why this has to be negative
        var vy = -Input.GetAxis(vAxis);


        //Debug.Log(vx);

        var velocity = new Vector2(vx, vy);
        if (velocity.magnitude > 1)
            velocity.Normalize();

        rbody.velocity = velocity * speed;

		if (velocity.magnitude > 0.1) {
			direction = new Vector3(velocity.normalized.x, velocity.normalized.y);
		}

        // Spike Extending
		try {
			if ((Input.GetAxis("J" + playerNum + "_ButtonA") > 0 || Input.GetKeyDown(spikeKey))) {
				foreach(GameObject cactiBall in cactiBalls)
				{
					Debug.Log ("spike");
					cactiBall.GetComponent<CactusController>().ExtendSpikes();
				}
			}
		} catch {
			if (Input.GetKeyDown(spikeKey)) {
				foreach(GameObject cactiBall in cactiBalls)
				{
					Debug.Log ("spike");
					cactiBall.GetComponent<CactusController>().ExtendSpikes();
				}
			}
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

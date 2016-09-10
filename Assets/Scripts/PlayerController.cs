using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D rbody;

	public float speed = 0f;

	bool spikesExtended = false;

    public int numSpikes;

    public GameObject spikePrefab;

	// Use this for initialization
	void Start () {
		player = gameObject;
		rbody = GetComponent<Rigidbody2D>();

        float spikeSpacing = 360f / numSpikes;
        for(int i = 0; i < numSpikes; i++)
        {
            GameObject newSpike = GameObject.Instantiate(spikePrefab);
            newSpike.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * spikeSpacing));
            newSpike.transform.parent = transform;
        }
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

		// Spike Extending
		if (Input.GetKeyDown ("space")) {
			if (!spikesExtended)
				ExtendSpikes ();
		}

	}

	void ExtendSpikes () {
		spikesExtended = true;
		foreach (Transform child in transform) {
			var sprite = child.Find ("Sprite");
			iTween.MoveBy (sprite.gameObject, iTween.Hash("x", 0f, "y", 0.5f, "z", 0f, "oncomplete", "RetractSpikes", "oncompletetarget", gameObject, "time", 1));
		}
	}

	void RetractSpikes () {
		foreach (Transform child in transform) {
			var sprite = child.Find ("Sprite");
			iTween.MoveBy (sprite.gameObject, iTween.Hash("x", 0f, "y", -0.5f, "z", 0f, "oncomplete", "OnRetractSpikesComplete", "oncompletetarget", gameObject, "time", 1));
		}
	}

	void OnRetractSpikesComplete() {
		spikesExtended = false;
	}
}

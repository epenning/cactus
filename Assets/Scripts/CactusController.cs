using UnityEngine;
using System.Collections;

public class CactusController : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D rbody;

	public bool spikesExtended = false;
	public bool spikesRetracting = false;

	public int numSpikes;

	public GameObject spikePrefab;

	public float spikeExpandSpeed;
	public float spikeRetractSpeed;

	// Use this for initialization
	protected void Start () {
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

	protected void ExtendSpikes () {
		spikesExtended = true;
		foreach (Transform child in transform) {
			var sprite = child.GetChild (0);
			// enable spike collisions while extended
			sprite.GetComponent<Collider2D> ().enabled = true;
			iTween.MoveBy (sprite.gameObject, iTween.Hash("x", 0f, "y", 0.5f, "z", 0f, "oncomplete", "RetractSpikes", "oncompletetarget", gameObject, "time", spikeExpandSpeed));
		}
	}

	protected void RetractSpikes () {
		if (!spikesRetracting) {
			spikesRetracting = true;
			foreach (Transform child in transform) {
				var sprite = child.GetChild (0);
				iTween.MoveBy (sprite.gameObject, iTween.Hash ("x", 0f, "y", -0.5f, "z", 0f, "oncomplete", "OnRetractSpikesComplete", "oncompletetarget", gameObject, "time", spikeRetractSpeed));
			}
		}
	}

	protected void OnRetractSpikesComplete() {
		if (spikesRetracting) {
			spikesExtended = false;
			spikesRetracting = false;

			// disable spike collisions while retracted
			foreach (Transform child in transform) {
				var sprite = child.GetChild (0);
				sprite.GetComponent<Collider2D> ().enabled = false;
			}
		}
	}
}

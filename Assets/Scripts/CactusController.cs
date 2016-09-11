using UnityEngine;
using System.Collections;

public class CactusController : MonoBehaviour {

	public bool spikesExtended = false;
	public bool spikesRetracting = false;

	public int numSpikes;

	public GameObject spikePrefab;

	public float spikeExpandSpeed;
	public float spikeRetractSpeed;

    public int ownerNum;

	// Use this for initialization
	protected void Start () {
		float spikeSpacing = 360f / numSpikes;
		for(int i = 0; i < numSpikes; i++)
		{
			GameObject newSpike = (GameObject) Instantiate(spikePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			newSpike.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * spikeSpacing));
			newSpike.transform.parent = transform;
            newSpike.GetComponentInChildren<SpikeController>().ownerNum = ownerNum;
		}
	}

	public void ExtendSpikes () {

        if (spikesExtended)
            return;

        Debug.Log ("test");


		spikesExtended = true;
		foreach (Transform child in transform) {
			var sprite = child.GetChild (0);
			// enable spike collisions while extended
			sprite.GetComponent<Collider2D> ().enabled = true;
			iTween.MoveBy (sprite.gameObject, iTween.Hash ("x", 0f, "y", 3f, "z", 0f, "oncomplete", "RetractSpikes", "oncompletetarget", gameObject, "time", spikeExpandSpeed));
		}
	}

	protected void RetractSpikes () {
		if (!spikesRetracting) {
			spikesRetracting = true;
			foreach (Transform child in transform) {
				var sprite = child.GetChild (0);
				iTween.MoveBy (sprite.gameObject, iTween.Hash ("x", 0f, "y", -3f, "z", 0f, "oncomplete", "OnRetractSpikesComplete", "oncompletetarget", gameObject, "time", spikeRetractSpeed));

			}
		}
	}

	protected void OnRetractSpikesComplete() {
		if (spikesRetracting) {
			spikesExtended = false;
			spikesRetracting = false;


			foreach (Transform child in transform) {
				var sprite = child.GetChild (0);
				// disable spike collisions while retracted
				sprite.GetComponent<Collider2D> ().enabled = false;
				if (sprite.GetComponent<SpikeController> ().caughtSomething == true) {
					foreach (Transform innerchild in sprite.transform) {
						if (innerchild.gameObject.tag == "Cactus") {
							innerchild.parent = transform.parent;
							transform.GetComponentInParent<PlayerObjectController> ().cactiBalls.Add (innerchild.gameObject);
							innerchild.gameObject.GetComponent<CactusController> ().ownerNum = ownerNum;
						}
					}
					// kill other player
					sprite.GetComponent<SpikeController> ().caughtPlayer.GetComponent<PlayerObjectController>().Kill();
				}
			}
		}
	}

	protected void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Powerup") {
			Debug.Log ("powerup pickup");
			// set player to having the powerup
			transform.GetComponentInParent<PlayerObjectController>().powerup = true;
			// disable the powerup !!
		}
	}
}

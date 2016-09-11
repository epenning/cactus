using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public GameObject parentGameObject;

    public int ownerNum;

    // Use this for initialization
    void Start () {
		parentGameObject = transform.parent.parent.gameObject;
		// disable collision originally
		gameObject.GetComponent<Collider2D>().enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Did I hit something?");
		Debug.Log (coll.gameObject.tag);
		// not our own gameobject
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Hit something!");
			if(coll.gameObject.GetComponent<PlayerObjectController>().playerNum != ownerNum)
            {
				foreach (Transform child in coll.gameObject.transform) {
					child.parent = gameObject.transform;
				}
            }
        }
	}
}

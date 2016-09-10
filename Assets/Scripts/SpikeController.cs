using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public GameObject parentGameObject;

	// Use this for initialization
	void Start () {
		parentGameObject = transform.parent.parent.gameObject;
		// disable collision originally
		gameObject.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// not our own gameobject
		if (coll.gameObject.tag != parentGameObject.tag) {
			Debug.Log ("Hit something!");

			coll.gameObject.transform.parent = gameObject.transform;
		}
	}
}

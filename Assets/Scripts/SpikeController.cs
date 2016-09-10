using UnityEngine;
using System.Collections;

public class SpikeController : MonoBehaviour {

	public GameObject parentGamObject;

	// Use this for initialization
	void Start () {
		parentGamObject = transform.parent.parent.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// not our own gameobject
		if (coll.gameObject.tag != parentGamObject.tag) {
			Debug.Log ("Hit something!");
		}
	}
}

﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpikeController : MonoBehaviour {

	public GameObject parentGameObject;

	public bool caughtSomething = false;
	public GameObject caughtPlayer;

    // Use this for initialization
    void Start () {
		parentGameObject = transform.parent.parent.gameObject;
		// disable collision originally
		gameObject.GetComponent<Collider2D>().enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		int ownerNum = transform.parent.parent.parent.GetComponent<PlayerObjectController> ().playerNum;

		Debug.Log ("Did I hit something?");
		Debug.Log (coll.gameObject.tag);
		// not our own gameobject
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Hit something! Player " + ownerNum + " hit " + coll.gameObject.GetComponent<PlayerObjectController>().playerNum);
            
			if(coll.gameObject.GetComponent<PlayerObjectController>().playerNum != ownerNum)
            {
				caughtSomething = true;
				caughtPlayer = coll.gameObject;

				foreach (Transform child in coll.gameObject.transform) {
					child.parent = gameObject.transform;
                    PlayerObjectController controllerScript = parentGameObject.transform.parent.GetComponent<PlayerObjectController>();
                    controllerScript.size++;
                    GameObject.Find("Player " + controllerScript.playerNum +  " Score").GetComponent<Text>().text = controllerScript.size.ToString() + "/" + GameObject.Find("GameController").GetComponent<GameController>().scoreLimit;
				}
				Debug.Assert (coll.gameObject.transform.childCount == 0);
            }
        }
	}
}

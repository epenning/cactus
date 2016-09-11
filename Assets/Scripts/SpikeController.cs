using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpikeController : MonoBehaviour {

	public GameObject parentGameObject;

    public int ownerNum;
	public bool caughtSomething = false;

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
				caughtSomething = true;
				foreach (Transform child in coll.gameObject.transform) {
					child.parent = gameObject.transform;
                    PlayerObjectController controllerScript = parentGameObject.transform.parent.GetComponent<PlayerObjectController>();
                    controllerScript.size++;
                    GameObject.Find("Player " + controllerScript.playerNum +  " Score").GetComponent<Text>().text = controllerScript.size.ToString() + "/" + GameObject.Find("GameController").GetComponent<GameController>().scoreLimit;

                }
            }
        }
	}
}

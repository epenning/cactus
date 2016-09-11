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

    public bool canSpike;

    public Color disabledColor;

    public Color poweredUpColor;

    public bool poweredUp = true;

    SpriteRenderer cactusSprite;

    PlayerObjectController parentController;

    public Color poweredAndDisabledColor;

    public GameObject flowerSpritePrefab;
    public GameObject flowerSprite;

	// Use this for initialization
	protected void Start () {
        //poweredUp = false;
        canSpike = true;
		float spikeSpacing = 360f / numSpikes;
        cactusSprite = GetComponent<SpriteRenderer>();
        parentController = GetComponentInParent<PlayerObjectController>();

        flowerSprite = GameObject.Instantiate(flowerSpritePrefab);
        flowerSprite.transform.parent = transform;

        pickFlowerColor();


        for (int i = 0; i < numSpikes; i++)
		{
			GameObject newSpike = (GameObject) Instantiate(spikePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			newSpike.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i * spikeSpacing));
			newSpike.transform.parent = transform;
		}
	}

    void pickFlowerColor()
    {
        switch (ownerNum)
        {
            case 4:
                flowerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/flower_of_cactus_purple");
                break;
            case 3:
                flowerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/flower_of_cactus_blue");
                break;
            case 2:
                flowerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/flower_of_cactus_green");
                break;
            case 1:
                flowerSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/flower_of_cactus_red");
                break;
            default:
                break;
        }
    }
    
    void Update()
    {
        if (!parentController.powerup)
            poweredUp = false;
        if (!canSpike)
        {
            if(poweredUp)
            {
                cactusSprite.color = poweredAndDisabledColor;
            }
            else
            {
                cactusSprite.color = disabledColor;
            }
        } else
        {

            if (poweredUp)
            {
                cactusSprite.color = poweredUpColor;
            }
            else
            {
                cactusSprite.color = Color.white;
            }
        }

    }

	public void ExtendSpikes () {

        if (spikesExtended || !canSpike)
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
			Debug.Log ("Retracted~~" + spikesRetracting);
			spikesRetracting = false;
			spikesExtended = false;

			foreach (Transform child in transform) {
				var sprite = child.GetChild (0);
				// disable spike collisions while retracted
				sprite.GetComponent<Collider2D> ().enabled = false;
				if (sprite.GetComponent<SpikeController> ().caughtSomething == true) {
					Debug.Log ("Children of spike which caught player:" + sprite.transform.childCount);
					foreach (GameObject innerchild in sprite.GetComponent<SpikeController>().stabbedPlayerObject.GetComponent<PlayerObjectController>().cactiBalls) {
						Debug.Log ("    Child tag: " + innerchild.gameObject.tag);
						if (innerchild.gameObject.tag == "Cactus") {
							
							innerchild.transform.parent = transform.parent;
							transform.GetComponentInParent<PlayerObjectController> ().cactiBalls.Add (innerchild.gameObject);
                            innerchild.gameObject.GetComponent<CactusController> ().ownerNum = ownerNum;
                            innerchild.gameObject.GetComponent<CactusController>().pickFlowerColor();

                        }
					}
					// kill other player
					sprite.GetComponent<SpikeController> ().caughtPlayer.GetComponent<PlayerObjectController>().Kill();
				}
				// reset caught something variable
				sprite.GetComponent<SpikeController> ().caughtSomething = false;
			}
		}
	}

	protected void OnTriggerEnter2D(Collider2D coll) {
		
		if (coll.gameObject.tag == "Powerup") {
			Debug.Log ("powerup pickup");
			// set player to having the powerup
			parentController.powerup = true;
            poweredUp = true;
			// disable the powerup !!
		} else if(coll.gameObject.tag == "Megaspike")
        {
            if(coll.gameObject.GetComponent<MegaspikeController>().ownerNum != ownerNum)
            {
                Debug.Log("I got hit by a megaspike!");
                disableCactus();
                GameObject.Destroy(coll.gameObject);
            }
        }
	}

    public void disableCactus()
    {
        if(canSpike && (parentController.size - parentController.numDisabled) >= 1)
        {
            canSpike = false;
            GetComponent<SpriteRenderer>().color = disabledColor;
            parentController.numDisabled++;
        }

    }
}

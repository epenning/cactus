using UnityEngine;
using System.Collections;

public class BackgroundTiler : MonoBehaviour {
    // Use this for initialization
    public int textureUnitSize;
    public int gameWidth;
    public int gameHeight;
	void Start () {
        gameObject.transform.localScale.Set(gameWidth/textureUnitSize, gameHeight/textureUnitSize, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour {

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;

	public Color p1color;
	public Color p2color;
	public Color p3color;
	public Color p4color;

	private bool b1selected;
	private bool b2selected;
	private bool b3selected;
	private bool b4selected;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			if (!b1selected) {
				button1.image.color = p1color;
				b1selected = true;
			} else {
				button1.image.color = Color.white;
				b1selected = false;
			}
		}
	}
}

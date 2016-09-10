using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class LobbyButton {

	public Button button;
	public Color color;
	public bool selected;


}

public class LobbyController : MonoBehaviour {

	public LobbyButton b1;
	public LobbyButton b2;
	public LobbyButton b3;
	public LobbyButton b4;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("joystick button 0")) {
			ToggleButton (b1);
		}
		//if (Input.GetAxis ("J2_ButtonX") || Input.GetKeyDown (KeyCode.S)) {
		//	ToggleButton (b2);
		//}
		//if (Input.GetAxis ("J3_ButtonX") || Input.GetKeyDown (KeyCode.D)) {
		//	ToggleButton (b3);
		//}
		//if (Input.GetAxis ("J4_ButtonX") || Input.GetKeyDown (KeyCode.C)) {
		//	ToggleButton (b4);
		//}
	}

	void ToggleButton (LobbyButton b) {
		if (!b.selected) {
			b.button.image.color = b.color;
			b.selected = true;
		} else {
			b.button.image.color = Color.white;
			b.selected = false;
		}
	}
}

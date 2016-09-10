using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class LobbyButton {

	public Button button;
	public Color color;
	public bool selected;
    public bool pressed;

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


        if(Input.GetKeyDown("joystick 1 button 2"))
        {
            ToggleButton(b1);
        }

        if (Input.GetKeyDown("joystick 2 button 2"))
        {
            ToggleButton(b2);
        }

        if (Input.GetKeyDown("joystick 3 button 2"))
        {
            ToggleButton(b1);
        }

        if (Input.GetKeyDown("joystick 4 button 2"))
        {
            ToggleButton(b2);
        }



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

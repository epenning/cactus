using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private int numActive;


	// Use this for initialization
	void Start () {
        numActive = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("joystick button 7") && numActive >= 2)
        {
            SceneManager.LoadScene(2);
        }


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
            ToggleButton(b3);
        }

        if (Input.GetKeyDown("joystick 4 button 2"))
        {
            ToggleButton(b4);
        }



    }

	void ToggleButton (LobbyButton b) {
		if (!b.selected) {
			b.button.image.color = b.color;
			b.selected = true;
            numActive++;
            if (numActive >= 2)
                ShowStartText();
		} else {
			b.button.image.color = Color.white;
			b.selected = false;
            numActive--;
            if (numActive <= 1)
                HideStartText();
		}
	}

    void ShowStartText ()
    {
        GameObject.Find("Start Text").GetComponent<Text>().color = Color.black;
    }

    void HideStartText ()
    {
        GameObject.Find("Start Text").GetComponent<Text>().color = Color.clear;
    }
}

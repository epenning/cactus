using UnityEngine;
using System.Collections;

public class InputTest : MonoBehaviour {

    float xDir;
    float yDir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        Vector2 unitDir = new Vector2(xDir, yDir).normalized;

        //Debug.Log(unitDir);

        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("pressed A!");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Debug.Log("pressed X!");
        }
    }
}

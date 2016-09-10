using UnityEngine;
using System.Collections;

public class InputTest : MonoBehaviour {

    float xDir;
    float yDir;

    public bool aIsPressed;
    public bool xIsPressed;

    public int playerNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        Vector2 unitDir = new Vector2(xDir, yDir).normalized;

        //Debug.Log(unitDir);

        if(Input.GetAxisRaw("J" + playerNum + "_ButtonA") > 0) 
        {
            if(!aIsPressed)
            {
                //Debug.Log("pressed A! " + Input.GetAxisRaw("J" + playerNum+ "_ButtonA"));
                aIsPressed = true;
            }

        } else
        {
            aIsPressed = false;
        }

        if (Input.GetAxisRaw("J" + playerNum + "_ButtonX") > 0)
        {
            if (!xIsPressed)
            {
                //Debug.Log("pressed X! " + Input.GetAxisRaw("J1_ButtonX"));
                xIsPressed = true;
            }
        }
        else
        {
            xIsPressed = false;
        }
    }
}

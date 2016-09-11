using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float timeLeft;
    public int scoreLimit;
    public bool gameRunning;

	void Start ()
    {
        GameObject.Find("Game Over Text").GetComponent<Text>().text = "";
        gameRunning = true;
    }

	// Update is called once per frame
	void Update () {
        if (gameRunning)
        {
            timeLeft -= Time.deltaTime;
            GameObject.Find("Timer Text").GetComponent<Text>().text = Mathf.Round(timeLeft).ToString();
            if (timeLeft < 0)
            {
                GameOver();
            }
        } else
        {
            if(Input.GetKeyDown("joystick button 2"))
            {
                SceneManager.LoadScene(2);
            }
        }
	}

	public void GameOver() {
        if (gameRunning)
        {
            gameRunning = false;
            string winner = "";
            int maxSize = 0;
            for (int i = 1; i <= 4; i++)
            {
                PlayerObjectController player = GameObject.Find("Player " + i + " Object").GetComponent<PlayerObjectController>();
                player.rbody.velocity = Vector3.zero;
                if (player.size > maxSize)
                {
                    winner = player.name;
                    maxSize = player.size;
                }
            }
            GameObject.Find("Game Over Text").GetComponent<Text>().text = "Player " + winner[7] + " wins!\n\nPress X to replay.";
            Debug.Log("Game Over!");
        }
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        }
	}

	void GameOver() {
        if (gameRunning)
        {
            gameRunning = false;
            string winner = "";
            int maxSize = 0;
            for (int i = 1; i <= 4; i++)
            {
                PlayerObjectController player = GameObject.Find("Player " + i + " Object").GetComponent<PlayerObjectController>();
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

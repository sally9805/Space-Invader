using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("r"))
		{
			ScoreKeeper.ResetScore();
			GameOver.isGameOver = false;
			Time.timeScale = 1;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
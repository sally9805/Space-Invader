using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	
	public static bool isGameOver = false;
	// Update is called once per frame
	void Update () {
		if (isGameOver) Time.timeScale = 0;
	}
}

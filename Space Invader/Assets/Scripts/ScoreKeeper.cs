using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private static float score;  // everyone has the same score
	private static Text scoreText; // everyone has the same text
	private static bool boolScore = false;
	public AudioClip scoreSound;
	private AudioSource _audioSource;
	
	// Use this for initialization
	internal void Start () {
		scoreText = GetComponent<Text>();
		_audioSource = GetComponent<AudioSource>();
		UpdateText();
	}

	internal void Update()
	{
		if (boolScore) PlayScoreSound();
	}
	

	public static void AddToScore(float points)
	{
		score += points;
		boolScore = true;
		UpdateText();
	}
	
	public void PlayScoreSound()
	{
		_audioSource.PlayOneShot(scoreSound);
		boolScore = false;
	}
	
	public static void ResetScore()
	{
		score = 0;
	}
	
	private static void UpdateText()
	{
		scoreText.text = String.Format("Score: {0}", score);
	}
}

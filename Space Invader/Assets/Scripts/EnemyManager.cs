using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	private Transform enemyHolder;
	public float speed;

	public GameObject enemyBullet;
	public Text winText;
	public Text restartText;
	public Text gameoverText;
	public float fireRate = 0.99f;
	public AudioClip winSound;
	public AudioClip loseSound;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("MoveEnemy", 0.1f, 0.3f);
		enemyHolder = GetComponent<Transform> ();
	}

	private void Update()
	{
		if (GameOver.isGameOver)
		{
			Time.timeScale = 0;
			gameoverText.enabled = true;
			restartText.enabled = true;
			GetComponent<AudioSource>().PlayOneShot(loseSound);
			GameOver.isGameOver = false;
		}
	}

	void MoveEnemy()
	{
		enemyHolder.position += Vector3.right * speed;
		foreach (Transform enemy in enemyHolder) {
			if (enemy.position.x < -10.5 || enemy.position.x > 10.5) {
				speed = -speed;
				enemyHolder.position += Vector3.down * 0.5f;
				return;
			}
			if (Random.value > fireRate) {
				Instantiate (enemyBullet, enemy.position, enemy.rotation);
				//Physics2D.IgnoreCollision(enemyBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
			if (enemy.position.y <= -4) {
				GameOver.isGameOver = true;
				Time.timeScale = 0;
			}
		}
		if (enemyHolder.childCount == 1) {
			CancelInvoke ();
			InvokeRepeating ("MoveEnemy", 0.1f, 0.25f);
		}
		if (enemyHolder.childCount == 0) {
			Time.timeScale = 0;
			winText.enabled = true;
			restartText.enabled = true;
			GetComponent<AudioSource>().PlayOneShot(winSound);
		}
	}
}

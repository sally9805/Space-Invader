using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	private Transform enemyBulletTrans;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		enemyBulletTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		enemyBulletTrans.position += Vector3.down * speed;
		if (enemyBulletTrans.position.y <= -7) Destroy(gameObject);
	}
	internal void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			GameOver.isGameOver = true;
		}
		else if (other.gameObject.CompareTag("Base"))
		{
			Destroy(gameObject);
			BaseHealth baseHealth = other.gameObject.GetComponent<BaseHealth>();
			baseHealth.health -= 1;
		}
		else if (other.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("enemy");
		}
	}
}

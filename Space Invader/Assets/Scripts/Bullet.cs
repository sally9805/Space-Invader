using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform bulletTrans;
	public float speed;
	
	// Use this for initialization
	void Start ()
	{
		bulletTrans = GetComponent<Transform>();
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		bulletTrans.position += Vector3.up * speed;
		if (bulletTrans.position.y >= 7) Destroy(gameObject);
	}

	internal void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
			ScoreKeeper.AddToScore(10.0f);
		}
		else if (other.gameObject.CompareTag("Base"))
		{
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Transform playerTrans;
	public float speed;
	public float boundLeft, boundRight;

	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;
	public AudioClip shootSound;

	private float nextBulletTime;
	
	// Use this for initialization
	void Start ()
	{
		playerTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 pos = playerTrans.position;
		if (Input.GetKey("d") || Input.GetKey("right")) pos.x += speed * Time.deltaTime;
		if (Input.GetKey("a") || Input.GetKey("left")) pos.x -= speed * Time.deltaTime;
		if (pos.x > boundLeft && pos.x < boundRight) playerTrans.position = pos;
	}
	
	void Update ()
	{
		if (Input.GetKey("space") && Time.time > nextBulletTime)
		{
			nextBulletTime = Time.time + fireRate;
			Instantiate(bullet, bulletSpawn.position + new Vector3(0,1,0), bulletSpawn.rotation);
			GetComponent<AudioSource>().PlayOneShot(shootSound);
		}
	}
}

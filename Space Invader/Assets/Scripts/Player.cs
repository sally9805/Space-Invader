using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	private Transform playerTrans;
	public float speed;
	public float boundLeft, boundRight;

	// Use this for initialization
	void Start ()
	{
		playerTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = playerTrans.position;
		if (Input.GetKey ("d") || Input.GetKey("right")) pos.x += speed * Time.deltaTime;
		if (Input.GetKey ("a") || Input.GetKey("left")) pos.x -= speed * Time.deltaTime;
		playerTrans.position = pos;
	}
}

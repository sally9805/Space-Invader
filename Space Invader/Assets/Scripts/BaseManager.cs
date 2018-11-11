using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{

	private Transform baseTrans;
	private int _childNum;
	public AudioClip destroySound;
	
	// Use this for initialization
	void Start ()
	{
		baseTrans = GetComponent<Transform>();
		_childNum = baseTrans.childCount;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var currentNum = baseTrans.childCount;
		if (currentNum != _childNum)
		{
			GetComponent<AudioSource>().PlayOneShot(destroySound);
			ScoreKeeper.AddToScore(-20.0f);
		}
		_childNum = currentNum;
		if (_childNum == 0) GameOver.isGameOver = true;
		
	}
}

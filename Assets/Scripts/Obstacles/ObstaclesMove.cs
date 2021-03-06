﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMove : MonoBehaviour {

	private const float velocity = 17;
	private const float timeLife = 8;



	void OnEnable()
	{
		Invoke ("DisableObj", timeLife);
	}

	private void DisableObj()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		CancelInvoke ();
	}
		
	private void Update()
	{
		transform.position -= new Vector3 (0, 0, velocity) * Time.deltaTime;
	
	}



}

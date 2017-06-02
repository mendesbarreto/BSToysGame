﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MoveStreet : MonoBehaviour {

	private const float MAX_DISTANCE = -100;

	private float SpeedStreet {
		get {return speedStreet;}
		set {speedStreet = value;}
	}
	[SerializeField]
	private float speedStreet = 10f;

	private StreetBuilder StreetBuilder {
		get{return streetBuilder;}
		set{streetBuilder=value;}
	}
	private StreetBuilder streetBuilder;

	private void Start() {
		streetBuilder = GameObject.FindObjectOfType<StreetBuilder> ();
	}

	private void Update () {
		MoveStreetForward ();
	}

	private void MoveStreetForward() {
		gameObject.transform.Translate (0, 0, speedStreet); //MOVIMENTAÇÃO DA PISTA
	}

	private bool isStreetDistanceAt(float z) 
	{
		if (gameObject.transform.position.z == z) 
		{
			return true;
		}
		return false;
	}

	private void Destroy()
	{
		//gameObject.SetActive (false);
	}
}

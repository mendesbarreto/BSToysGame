﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StreetControler : MonoBehaviour {

	public GameObject FirstObjStreet {
		get {return firstObjStreet; }
		set { firstObjStreet = value; }
	}
	[SerializeField]
	private GameObject firstObjStreet;

	public GameObject SecondObjStreet {
		get {return secondObjStreet; }
		set { secondObjStreet = value; }
	}
	[SerializeField]
	private GameObject secondObjStreet;

	//CONTROLADOR DA PISTA
	[SerializeField]
	private int defaultStreetDiamiter = 100;
	private const float MAX_DISTANCE = -100;
	private GameObject currentStreet;

	private void Start(){
		LoadResources ();
	}

	private void LoadResources() {
		currentStreet = firstObjStreet;

	}

	private void Update () {
		if (VerifyDistance ()) {
			ChangePosition ();
			ChangeCurrentStreet ();
		}
	}


	private bool VerifyDistance(){
		if (currentStreet.transform.position.z <= MAX_DISTANCE) 
		{
			return true;
		}
		return false;
	}


	private void ChangePosition(){
		currentStreet.transform.position = new Vector3 (currentStreet.transform.position.x, currentStreet.transform.position.y, OldPosition() + defaultStreetDiamiter);
	}

	private void ChangeCurrentStreet(){
		if (VerifyCurrentStreet ()) 
		{
			currentStreet = secondObjStreet;
		}
		else 
		{
			currentStreet = firstObjStreet;
		}
	}

	private float OldPosition(){
		if (VerifyCurrentStreet ()) 
		{
			return secondObjStreet.transform.position.z;
		} 
		else 
		{
			return firstObjStreet.transform.position.z;
		}
	}

	private bool VerifyCurrentStreet(){
		if (currentStreet == firstObjStreet) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
}

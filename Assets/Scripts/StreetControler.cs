using System.Collections;
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
		if (currentStreet.transform.position.z == MAX_DISTANCE) 
		{
			Debug.Log ("currentStreet trigou");
			return true;
		}
		return false;
	}


	private void ChangePosition(){
		currentStreet.transform.position = new Vector3 (currentStreet.transform.position.x, currentStreet.transform.position.y, oldPosition() + defaultStreetDiamiter);
	}

	private void ChangeCurrentStreet(){
		if (verifyCurrentStreet ()) 
		{
			currentStreet = secondObjStreet;
		}
		else 
		{
			currentStreet = firstObjStreet;
		}
	}

	private float oldPosition(){
		if (verifyCurrentStreet ()) 
		{
			return secondObjStreet.transform.position.z;
		} 
		else 
		{
			return firstObjStreet.transform.position.z;
		}
	}

	private bool verifyCurrentStreet(){
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

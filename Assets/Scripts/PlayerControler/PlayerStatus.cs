using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour {

	private string objectTag = "Obstacles";

	public static bool IsLive
	{
		get { return isLive; }
		set { isLive = value; }
	}
	private static bool isLive = true;


	private void Start(){
		LoadResources ();
	}

	private void LoadResources(){
		isLive = true;
	}

	//COLIDIR COM OBSTACULOS
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == objectTag)
		{
			isLive = false;
		}
	}


}

﻿using UnityEngine;
using System.Collections;

public class CloseCall : MonoBehaviour
{

	// Use this for initialization

	BoxCollider box;
	void Start ()
	{
		box = GetComponent<BoxCollider> ();

		box.size = new Vector3 (1, 1, 0.8f);
	}

	Vector3 entrancePoint ;
	void OnTriggerEnter (Collider inc)
	{

		if (inc.tag.Contains ("Player")) {
			
			entrancePoint = inc.transform.position;
			if (NitrousIndicator.NitrousCount < 100)
				NitrousIndicator.NitrousCount += 1.0f;
			NitrousIndicator.Static.UpdateNitrousDisplay ();
			
		}
	}

	void OnTriggerExit (Collider inc)
	{

		if (inc.tag.Contains ("Player")) {


			float distace = Vector3.Distance (inc.transform.position, entrancePoint);

			if (distace > 20.0f) {
				//call ingame show +10 coins 
				box.enabled = false;
				UIControl.Static.showCoinAwardMessage ();
//				Debug.Log(" close call added coins ");
			}

		 
			
		}
	}
}

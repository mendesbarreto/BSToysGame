using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StreetBuilder : MonoBehaviour {

	//VARIAÇÕES
	public GameObject cityStreet;
	public GameObject countryStreet;
	public GameObject highwayStreet;
	private GameObject mainStreet;

	//CONTROLADOR DE REPETIÇÕES DE PISTA
	[SerializeField]
	private int timeChange = 3; 
	private int timeChangeCounter = 0;

	public static bool isDestroyed = false;


	private void Start(){
		mainStreet = cityStreet;
	}

	private void Update () {
		ChangeStreet();
		SpawnStreet ();
	}

	private void ChangeStreet(){
		if (timeChangeCounter == timeChange && mainStreet == cityStreet) 
		{
			mainStreet = highwayStreet;
			timeChangeCounter = 0;
		} 
		else if (timeChangeCounter == timeChange && mainStreet == highwayStreet) 
		{
			mainStreet = countryStreet;
			timeChangeCounter = 0;
		} 
		else if (timeChangeCounter == timeChange && mainStreet == countryStreet) 
		{
			mainStreet = cityStreet;
			timeChangeCounter = 0;
		}

	}


	private void SpawnStreet() {
		if (isDestroyed == true) 
		{
			Vector3 spawnPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z-1);//LOCAL DO SPAWN
			Instantiate (mainStreet, spawnPoint, Quaternion.identity);

			isDestroyed = false;
			timeChangeCounter++;
		}
	}

}

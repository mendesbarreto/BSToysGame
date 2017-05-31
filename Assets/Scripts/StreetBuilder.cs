using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StreetBuilder : MonoBehaviour {

	//VARIAÇÕES
	public GameObject cityStreet;
	public GameObject country;
	public GameObject highway;
	private GameObject mainStreet;

	//CONTROLADOR DE REPETIÇÕES DE PISTA
	[SerializeField]
	private int timeChange = 3; 
	private int cont = 0;

	private void Start(){
		mainStreet = cityStreet;
	}

	private void Update () {
		ChangeStreet();
		SpawnStreet ();
	}

	private void ChangeStreet(){
		if (cont == timeChange && mainStreet == cityStreet) 
		{
			mainStreet = highway;
			cont = 0;
		} 
		else if (cont == timeChange && mainStreet == highway) 
		{
			mainStreet = country;
			cont = 0;
		} 
		else if (cont == timeChange && mainStreet == country) 
		{
			mainStreet = cityStreet;
			cont = 0;
		}
	}


	private void SpawnStreet() {
		if (MoveStreet.isDestroyed == true) 
		{
			Vector3 spawnPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z-1);//LOCAL DO SPAWN
			Instantiate (mainStreet, spawnPoint, Quaternion.identity);

			MoveStreet.isDestroyed = false;
			cont++;
		}

	}
}

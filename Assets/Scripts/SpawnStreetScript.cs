using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStreetScript : MonoBehaviour {

	//VARIAÇÕES
	public GameObject street1;
	public GameObject street2;
	public GameObject street3;
	private GameObject mainStreet;

	//CONTROLADOR DE REPETIÇÕES DE PISTA
	[SerializeField]
	private int timeChange = 3; 
	private int cont = 0;

	void Start(){
		mainStreet = street1;
	}
		
	void Update () {
		ChangeStreet();
		SpawnStreet ();
	}
		
	void ChangeStreet(){
		if (cont == timeChange && mainStreet == street1) 
		{
			mainStreet = street2;
			cont = 0;
		} 
		else if (cont == timeChange && mainStreet == street2) 
		{
			mainStreet = street3;
			cont = 0;
		} 
		else if (cont == timeChange && mainStreet == street3) 
		{
			mainStreet = street1;
			cont = 0;
		}
	}


	void SpawnStreet() {
		if (StreetScript.isDestroyed == true) 
		{
			Vector3 spawnPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z-1);//LOCAL DO SPAWN
			Instantiate (mainStreet, spawnPoint, Quaternion.identity);

			StreetScript.isDestroyed = false;
			cont++;
		}

	}
}

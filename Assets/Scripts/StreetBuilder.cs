using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StreetBuilder : MonoBehaviour {

	//VARIAÇÕES
	public GameObject HighwayStreet {
		get {return highwayStreet; }
		set { highwayStreet = value; }
	}
	//[SerializeField]
	private GameObject highwayStreet;

	public GameObject CountryStreet {
		get {return countryStreet; }
		set { countryStreet = value; }
	}
	//[SerializeField]
	private GameObject countryStreet;

	public GameObject CityStreet {
		get {return cityStreet; }
		set { cityStreet = value; }
	}
	//[SerializeField]
	private GameObject cityStreet;

	private GameObject currentStreetType;
	private GameObject currentStreetInstance;

	[SerializeField]
	private GameObject mainStreet;

	private List<GameObject> streets;

	private float duration = 1.0f;
	private float timer = 0f;

	//CONTROLADOR DE REPETIÇÕES DE PISTA
	[SerializeField]
	private int defaultSpawnDiamiter = 100;
	private int defaultOffSetZ = -1;

	public bool IsDestroyed {
		get{return isDestroyed;}
		set
		{
			print ("Is Destroyed was set:");
			print (value);
			isDestroyed = value;
		}
	}
	private bool isDestroyed = false;


	private void Start(){
		streets = new List<GameObject> ();
		LoadResources ();
		GotoNextStreetType ();
	}

	private void LoadResources() {
		cityStreet = PrefabsLoader.Instance.Loader (PrefabsLoader.StreetsType.CITY);
		highwayStreet = PrefabsLoader.Instance.Loader (PrefabsLoader.StreetsType.HIGH_WAY);
		countryStreet = PrefabsLoader.Instance.Loader (PrefabsLoader.StreetsType.COUNTRY);
		currentStreetType = cityStreet;
	}

	private void Update () {
		if (ShouldChangeSreet ()) {
			ResetTimer ();
			GotoNextStreetType ();
		} else {
			IncreaseTimer ();
		}
	}

	private void IncreaseTimer() {
		timer += Time.deltaTime;
	}

	private void ResetTimer() {
		timer = 0;
	}

	private void GotoNextStreetType() {
		ChangeStreetType();
		SpawnStreet();
	}

	private bool ShouldChangeSreet() 
	{
		if (timer >= duration) 
		{
			return true;
		}

		return false;
	}

	private void ChangeStreetType(){
		if (currentStreetType == cityStreet) 
		{
			currentStreetType = highwayStreet;
		} 
		else if (currentStreetType == highwayStreet) 
		{
			currentStreetType = countryStreet;
		} 
		else if (currentStreetType == countryStreet) 
		{
			currentStreetType = cityStreet;
		}
	}
		
	private void SpawnStreet() {
		currentStreetInstance = CreateNewStreet ();
	}

	private GameObject GetAvaliableStreet() {
		foreach (GameObject go in streets) {
			if (!go.activeSelf) {
				go.transform.position = GetNewSpawPosition ();
				go.SetActive (true);
				return go;
			}
		}
		return CreateNewStreet();
	}

	private GameObject CreateNewStreet() {
		var go =  (GameObject)Instantiate (currentStreetType, GetNewSpawPosition(), Quaternion.identity);
		streets.Add (go);
		go.transform.parent = mainStreet.transform;
		return go;	
	}

	private Vector3 GetNewSpawPosition() {
		var oldPosition = currentStreetInstance != null ? currentStreetInstance.transform.position : Vector3.zero;
		var x = oldPosition.x;
		var y = oldPosition.y;
		var z = (oldPosition.z + defaultSpawnDiamiter) + defaultOffSetZ;
		return new Vector3 (x, y , z);
	}
}

using System;
using UnityEngine;

public sealed class PrefabsLoader: MonoBehaviour
{
	public enum StreetsType {
		CITY,
		COUNTRY,
		HIGH_WAY
	}

	public struct StreetsNames {
		public const String CITY = "city_street";
		public const String COUNTRY = "coutry_street";
		public const String HIGH_WAY = "highway_street";
	}

	private static readonly PrefabsLoader instance = new PrefabsLoader();
	public static PrefabsLoader Instance
	{
		get 
		{
			return instance; 
		}
	}

	private PrefabsLoader(){}

	public GameObject Loader(StreetsType type ) 
	{
		var path = GetFilePathBy (type);
		var res = Resources.Load (path);
		if (res != null) {
			Debug.Log("The resource with " + path + " will be load");
			return (GameObject)Instantiate(res);	
		}
		Debug.Log("Resouce NOT FOUND !!!!!!!!!! =(");
		return null;
	}

	private String GetFilePathBy(StreetsType type) 
	{
		String streetName = "";

		switch (type) 
		{
		case StreetsType.CITY:
			streetName = StreetsNames.CITY;
			break;
		case StreetsType.COUNTRY:
			streetName = StreetsNames.COUNTRY;
			break;
		case StreetsType.HIGH_WAY:
			streetName = StreetsNames.HIGH_WAY;
			break;
		}

		return streetName;
	}

}


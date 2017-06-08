using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBuilder : MonoBehaviour {

	// DIFICULDADE
	private float currentDifficulty;
	private const float MAX_DIFFICULTY = 0.3f;
	private const float MIN_DIFFICULTY = 1f;
	private const int timeChangeDifficulty = 10;
	private int countTimeDifficulty;
	private float timerSpawn;

	//OBSTACULOS
	public GameObject Obstacles {
		get { return obstacles; }
		set { obstacles = value; }
	}
	[SerializeField]
	private GameObject obstacles;
	private const int qntdObstacles = 20;
	List<GameObject> obstaclesList;
	private int LastPointer = 5;

	private void Start()
	{
		LoadResources ();
	}


	private void LoadResources()
	{
		currentDifficulty = MIN_DIFFICULTY;
		timerSpawn = MIN_DIFFICULTY;

		obstaclesList = new List<GameObject> ();
		for (int i = 0; i < qntdObstacles; i++) 
		{
			GameObject obj = (GameObject)Instantiate (obstacles);
			obj.SetActive (false);
			obstaclesList.Add (obj);
		}
	}


	private void Update(){
	
		Timer ();
		if (timerSpawn <= 0) 
		{
			Spawn();
			timerSpawn = Dificult();
		}
	}

	private void Timer()
	{
		timerSpawn -= Time.deltaTime;
	}

	private void Spawn()
	{
		for (int i = 0; i < obstaclesList.Count; i++) 
		{
			if (!obstaclesList [i].activeInHierarchy) 
			{
				obstaclesList [i].transform.position = LocalSpawn();
				obstaclesList [i].transform.rotation = transform.rotation;
				obstaclesList [i].SetActive (true);
				break;
			}
		}
		countTimeDifficulty++;
	}
		

	private float Dificult()
	{
		
		if (countTimeDifficulty == timeChangeDifficulty && currentDifficulty >= MAX_DIFFICULTY) 
		{
			currentDifficulty = currentDifficulty - 0.1f;
			countTimeDifficulty = 0;

		}
		return currentDifficulty;
	}
		


	private Vector3 LocalSpawn()
	{
		int randomSpawn = Random.Range(0, 3);

		//EVITAR REPETICAO DE OBSTACULO
		if (LastPointer == randomSpawn) 
		{
			return LocalSpawn ();
		}
		LastPointer = randomSpawn;

		var localSpawn = Vector3.zero;
		switch (randomSpawn)
		{
		case 0:
		 	localSpawn = new Vector3(0, 1.55f, 100);
			break;
		case 1:
			localSpawn = new Vector3(-4, 1.55f, 100);
			break;
		case 2:
			localSpawn = new Vector3(4.5f, 1.55f, 100);
			break;
		default:
			Debug.Log ("Unexpected value localSpawn = " + localSpawn);
			break;
		}
		return localSpawn;
	}
		
}





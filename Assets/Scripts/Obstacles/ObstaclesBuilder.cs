using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBuilder : MonoBehaviour {

    // DIFICULDADE
    private float currentDifficulty;
    private const float MAX_DIFFICULTY = 0.4f;
    private const float MIN_DIFFICULTY = 1.1f;
    private const int timeChangeDifficulty = 10;
    private int countTimeDifficulty;
    private float timerSpawn;


    //LOCAIS POSSIVEIS
    private readonly Vector3 left = new Vector3(-0.82f, 1.82f, 100);
    private readonly Vector3 mid = new Vector3(0, 1.82f, 100);
    private readonly Vector3 right = new Vector3(0.82f, 1.82f, 100);

    //OBSTACULOS
    public GameObject Obstacles
    {
        get { return obstacles; }
        set { obstacles = value; }
    }
    [SerializeField]
    private GameObject obstacles;

    public GameObject ObstaclesTruck
    {
        get { return obstaclesTruck; }
        set { obstaclesTruck = value; }
    }
    [SerializeField]
    private GameObject obstaclesTruck;

    public GameObject ObstaclesTruck2
    {
        get { return obstaclesTruck2; }
        set { obstaclesTruck2 = value; }
    }
    [SerializeField]
    private GameObject obstaclesTruck2;

    public GameObject ObstaclesTruck3
    {
        get { return obstaclesTruck3; }
        set { obstaclesTruck3 = value; }
    }
    [SerializeField]
    private GameObject obstaclesTruck3;


    public GameObject DoubleObstacles
    {
        get { return doubleobstacles; }
        set { doubleobstacles = value; }
    }
    [SerializeField]
    private GameObject doubleobstacles;

    public GameObject DoubleObstaclesType2
    {
        get { return doubleobstaclesType2; }
        set { doubleobstaclesType2 = value; }
    }
    [SerializeField]
    private GameObject doubleobstaclesType2;


    private const int qntdObstacles = 6;
    List<GameObject> obstaclesList;
    private int LastPointer = 5;

    private void Start()
    {
        LoadResources();
    }


    private void LoadResources()
    {
        currentDifficulty = MIN_DIFFICULTY;
        timerSpawn = MIN_DIFFICULTY;

        obstaclesList = new List<GameObject>();
        for (int i = 0; i < qntdObstacles; i++)
        {
            GameObject obj = (GameObject)Instantiate(obstacles);
            GameObject obj2 = (GameObject)Instantiate(obstaclesTruck);
            GameObject obj3 = (GameObject)Instantiate(obstaclesTruck2);
            GameObject obj4 = (GameObject)Instantiate(obstaclesTruck3);


            obj.SetActive(false);
            obstaclesList.Add(obj);
            obj2.SetActive(false);
            obstaclesList.Add(obj2);
            obj3.SetActive(false);
            obstaclesList.Add(obj3);
            obj4.SetActive(false);
            obstaclesList.Add(obj4);
        }

        doubleobstacles = (GameObject)Instantiate(doubleobstacles);
        doubleobstacles.SetActive(false);

        doubleobstaclesType2 = (GameObject)Instantiate(doubleobstaclesType2);
        doubleobstaclesType2.SetActive(false);
    }


    private void Update()
    {

        Timer();
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

            if (!obstaclesList[i].activeInHierarchy)
            {
                var local = LocalSpawn();

                GameObject currentObject = SelectDoubleObstacle();

                if (local == mid && Random.Range(0, 3) == 0 && !currentObject.activeInHierarchy)
                {
                    currentObject.transform.position = local;
                    currentObject.transform.rotation = transform.rotation;
                    currentObject.SetActive(true);
                    break;

                }
                else
                {
                    obstaclesList[i].transform.position = local;
                    obstaclesList[i].transform.rotation = transform.rotation;
                    obstaclesList[i].SetActive(true);
                    break;
                }
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
            return LocalSpawn();
        }
        LastPointer = randomSpawn;

        var localSpawn = Vector3.zero;
        switch (randomSpawn)
        {
            case 0:
                localSpawn = mid;
                break;
            case 1:
                localSpawn = left;
                break;
            case 2:
                localSpawn = right;
                break;
            default:
              
                break;
        }
        return localSpawn;
    }





    private GameObject SelectDoubleObstacle()
    {
        int randomObstacle = Random.Range(0, 2);

        if (randomObstacle == 0)
        {
            return doubleobstacles;
        }
        else
        {
            return doubleobstaclesType2;
        }
    }

}





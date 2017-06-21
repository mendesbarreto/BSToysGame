using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

	private string objectTag = "Obstacles";

	/*public static bool IsLive
	{
		get { return isLive; }
		set { isLive = value; }
	}
	private static bool isLive = true;
    */

	private void Start(){
		LoadResources ();
	}

	private void LoadResources(){
        MainGameStatus.instance._isLive = true;
	}

	//COLIDIR COM OBSTACULOS
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == objectTag)
		{
            MainGameStatus.instance._isLive = false;
            SceneManager.LoadScene("GameOver");
        }
	}


}

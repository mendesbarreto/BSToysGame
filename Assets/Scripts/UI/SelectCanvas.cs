using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCanvas : MonoBehaviour {

	public Button SelectPlayer {
		get {return selectPlayer; }
		set { selectPlayer = value; }
	}
	[SerializeField]
	private Button selectPlayer;


	public void Select()
	{
		LoadScene();
	}


	private static void LoadScene()
	{
        MainGameStatus.instance._playGame = true;
		SceneManager.LoadScene("Game");
	}
}

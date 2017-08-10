using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	[SerializeField]
	private Canvas PauseScreen;

	public Button Menu {
		get {return menu; }
		set { menu = value; }
	}
	[SerializeField]
	private Button menu;

	public Button ContinueBtn {
		get {return continueBtn; }
		set { continueBtn = value; }
	}
	[SerializeField]
	private Button continueBtn;


	public Button Restart {
		get {return restart; }
		set { restart = value; }
	}
	[SerializeField]
	private Button restart;


	private void Start(){
		LoadResources ();
	
	}

	private void LoadResources (){
		PauseScreen.enabled = false;
	}



	public void ContinuePress(){
		Time.timeScale = 1.0f;
		PauseScreen.enabled = false;

	}

	public void RestartPress()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1.0f;
		PauseScreen.enabled = false;
	}

	public void MenuPress()
	{
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1.0f;
		PauseScreen.enabled = false;
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text TxtScore{
		get {return txtScore; }
		set { txtScore = value; }
	}
	[SerializeField]
	private Text txtScore; 



	public Button Restart {
		get {return restart; }
		set { restart = value; }
	}
	[SerializeField]
	private Button restart;


	public Button Menu {
		get {return menu; }
		set { menu = value; }
	}
	[SerializeField]
	private Button menu;


	public Button Quit {
		get {return quit; }
		set { quit = value; }
	}
	[SerializeField]
	private Button quit;



	private void Start(){
		LoadResources ();
	}


	private void LoadResources() {
		
		txtScore.text = "SCORE: " + Score.ScoreManager.ToString();
	}



	public void RestartPress()
	{
		SceneManager.LoadScene("Game");
	}

	public void MenuPress()
	{
		SceneManager.LoadScene("Menu");
	}

	public void QuitPress()
	{
		Application.Quit ();
	}




}

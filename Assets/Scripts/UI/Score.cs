using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class Score : MonoBehaviour {

	public Text TxtScore{
		get {return txtScore; }
		set { txtScore = value; }
	}
	[SerializeField]
	private Text txtScore; 


	/*public static int ScoreManager
	{
		get { return score; }
		set { score = value; }
	}
	private static int score;
    */
	private float perSecond = 0.1f;

	private void Start(){
		LoadResources ();
	}

	private void LoadResources() {
		txtScore = GameObject.Find("Score").GetComponent<Text>();
        MainGameStatus.instance._score = 0;

	}

	private void Update () {
		if (VerifyPlayerLive ()) {
			CountScore ();
		}
		WriteScore ();
	}


	private void CountScore()
	{
		perSecond -= Time.deltaTime;
		if (perSecond <= 0) 
		{
            MainGameStatus.instance._score++;
			perSecond = 0.1f;
		}
	}

	private void WriteScore(){
		txtScore.text = "SCORE: " + MainGameStatus.instance._score.ToString();
	}
		

	private bool VerifyPlayerLive(){
	
		if (MainGameStatus.instance._isLive) {
			return true;
		} 
		else {
			return false;
		}
	}

}

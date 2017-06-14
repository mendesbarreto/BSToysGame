using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Score : MonoBehaviour {

	public Text TxtScore{
		get {return txtScore; }
		set { txtScore = value; }
	}
	[SerializeField]
	private Text txtScore; 

	private int score;
	private float perSecond = 0.1f;

	private void Start(){
		LoadResources ();
	}

	private void LoadResources() {
		txtScore = GameObject.Find("Score").GetComponent<Text>();
		score = 0;
	}

	private void Update () {
		CountScore ();
		WriteScore ();
	}


	private void CountScore()
	{
		perSecond -= Time.deltaTime;
		if (perSecond <= 0) 
		{
			score++;
			perSecond = 0.1f;
		}
	}

	private void WriteScore(){
		txtScore.text = "SCORE: " + score.ToString();
	}
		
}

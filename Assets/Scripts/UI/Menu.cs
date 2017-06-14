using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class Menu : MonoBehaviour {

	public Button Play {
		get {return play; }
		set { play = value; }
	}
	[SerializeField]
	private Button play;


	public Button Score {
		get {return score; }
		set { score = value; }
	}
	[SerializeField]
	private Button score;


	public Button QRCode {
		get {return qrCode; }
		set { qrCode = value; }
	}
	[SerializeField]
	private Button qrCode;


	public Button Credits {
		get { return credits; }
		set { credits = value; }
	}
	[SerializeField]
	private Button credits;


	public void PlayPress()
	{
		SceneManager.LoadScene("MenuSelect");
	}

	public void ScorePress()
	{
		Debug.Log("Score button");
	}

	public void QRCodePress()
	{
		Debug.Log("QR Code button");
	}

	public void CreditsPress()
	{
		Debug.Log("Credits button");
	}
}

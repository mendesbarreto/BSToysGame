using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopScoreMenu : MonoBehaviour {

	public Button Menu {
		get {return menu; }
		set { menu = value; }
	}
	[SerializeField]
	private Button menu;




	public void MenuPress()
	{
		SceneManager.LoadScene("Menu");
	}

}

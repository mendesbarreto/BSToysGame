using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour {

	public Button PlayerWhite {
		get {return playerWhite; }
		set { playerWhite = value; }
	}
	[SerializeField]
	private Button playerWhite;

	public Button PlayerRed {
		get {return playerRed; }
		set { playerRed = value; }
	}
	[SerializeField]
	private Button playerRed;

	public Button PlayerBlack {
		get {return playerBlack; }
		set { playerBlack = value; }
	}
	[SerializeField]
	private Button playerBlack;




    //ARRUMAR DAQUI EM DIANTE -----------------------------------------------------------
    public static int PlayerSelect
    {
        get { return playerSelect; }
        set { playerSelect = value; }
    }
    private static int playerSelect;
	

	/*private static readonly SelectPlayer instance = new SelectPlayer();
	public static SelectPlayer Instance
	{
		get 
		{
			return instance; 
		}
	}
	private SelectPlayer(){}
*/




	public void SelectWhite()
	{
		PlayerSelect = 0;
		SceneManager.LoadScene("Game");
	}

	public void SelectRed()
	{
		PlayerSelect = 1;
		SceneManager.LoadScene("Game");
	}

	public void SelectBlack()
	{
		PlayerSelect = 2;
		SceneManager.LoadScene("Game");
	}



}

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

    public static int PlayerSelect
    {
        get { return playerSelect; }
        set { playerSelect = value; }
    }
    private static int playerSelect;


    public void SelectWhite()
	{
		PlayerSelect = 0;
        LoadScene();
    }

    public void SelectRed()
	{
		PlayerSelect = 1;
        LoadScene();
    }

	public void SelectBlack()
	{
		PlayerSelect = 2;
        LoadScene();

    }


    private static void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }


}

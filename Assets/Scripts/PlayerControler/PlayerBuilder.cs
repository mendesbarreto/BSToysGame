using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilder : MonoBehaviour {

	public GameObject PlayerWhite {
		get {return playerWhite; }
		set { playerWhite = value; }
	}
	[SerializeField]
	private GameObject playerWhite;

	public GameObject PlayerRed {
		get {return playerRed; }
		set { playerRed = value; }
	}
	[SerializeField]
	private GameObject playerRed;

	public GameObject PlayerBlack {
		get {return playerBlack; }
		set { playerBlack = value; }
	}
	[SerializeField]
	private GameObject playerBlack;

    private readonly int Player = MainGameStatus.instance._playerselect;

	private void Start () 
	{
		BuildPlayerType();
	}
		
	private void BuildPlayerType()
	{
		Instantiate(VerifyPlayerType(), new Vector3 (0f, 1.72f, -22f), Quaternion.identity);
	}

	private GameObject VerifyPlayerType(){
		if(Player == 0)
		{
			return PlayerWhite;
		}
		if(Player == 1)
		{
			return PlayerRed;
		}
		if (Player == 2)
		{
			return PlayerBlack;
		}
		return null;
	}

}

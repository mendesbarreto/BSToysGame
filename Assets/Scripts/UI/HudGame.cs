using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudGame : MonoBehaviour {


	public Text TxtVelocity{
		get {return txtVelocity; }
		set { txtVelocity = value; }
	}
	[SerializeField]
	private Text txtVelocity; 

	private int velocity;
	private float perSecond = 1;
	private int gear = 40;
	private const int MAX_SPEED = 200;

	//GEAR
	private const int BOTTOM_GEAR = 60;
	private const int SECOND_GEAR = 100;
	private const int THIRD_GEAR = 160;
	private const int FOURTH_GEAR = 180;

	private void Start(){
		LoadResources ();
	}

	private void LoadResources() {
		txtVelocity = GameObject.Find("Velocity").GetComponent<Text>();
		velocity = 0;
	}

	private void Update () {
		Acceleration ();
		WriteVelocity ();
	}


	private void Acceleration()
	{
		perSecond -= Time.deltaTime * gear;
		if (perSecond <= 0 && velocity < MAX_SPEED) 
		{
			velocity++;
			perSecond = 1;

			if (velocity == BOTTOM_GEAR || velocity == SECOND_GEAR || velocity == THIRD_GEAR || velocity == FOURTH_GEAR) {
				gear = gear / 2;
			}
		}
	}

	private void WriteVelocity(){
		txtVelocity.text = velocity.ToString();
	}



}

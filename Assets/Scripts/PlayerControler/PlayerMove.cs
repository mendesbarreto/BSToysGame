using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//ATRIBUTOS
	private Rigidbody playerRb;
	[SerializeField]
	private float speedPlayer = 5;
	private float position;

	//POSICOES POSSIVEIS
	[SerializeField]
	private float left = -4;
	[SerializeField]
	private float mid = 0;
	[SerializeField]
	private float right = 4.5f;

	//EFEITO CURVA
	private float rangeCurve = 30;
	private Vector3 curve = new Vector3(0, 0, 0);
	private float CurveTimecounter = 0.3f;
	private const int SPEED_ROTACAO = 10;
	private const int SPEED_VOLTA_ROTACAO = 130;


	private void Start(){
		LoadResources ();
	}


	private void LoadResources() {
		playerRb = GetComponent<Rigidbody>();

	}


	private void FixedUpdate()
	{
		Controler();
		Move();
		CurveEffect();
	}


	private void Controler()
	{
		if (Input.GetKeyDown ("d")) {
			if (position == left) {
				position = mid;
			} else if (position == mid) {
				position = right;
			}
			curve.y = rangeCurve;
			CurveTimecounter = 0.3f;
		}

		if (Input.GetKeyDown ("a")) {
			if (position == right) {
				position = mid;
			} else if (position == mid) {
				position = left;
			}
			curve.y = -rangeCurve;
			CurveTimecounter = 0.3f;
		}

	}


	private void Move(){
		Vector3 final = new Vector3(position, playerRb.transform.position.y, playerRb.transform.position.z);
		playerRb.transform.position = Vector3.Lerp(transform.position, final, Time.deltaTime * speedPlayer);
	}


	private void CurveEffect(){
		//CURVA
		if (curve.y == rangeCurve || curve.y == -rangeCurve)
		{
			playerRb.transform.rotation = Quaternion.Lerp(playerRb.transform.rotation, Quaternion.Euler(curve), Time.deltaTime * SPEED_ROTACAO);
			CurveTimecounter -= Time.deltaTime;
		}

		//VOLTA EIXO    
		if (CurveTimecounter <= 0)
		{
			curve.y = 0;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, Time.deltaTime * SPEED_VOLTA_ROTACAO);
		}
	}
}

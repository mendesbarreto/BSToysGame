using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StreetMove : MonoBehaviour {
    
	private readonly float speedStreet = -0.25f;

	private void Update () {
		MoveStreetForward ();
	}

	private void MoveStreetForward() {
		gameObject.transform.Translate (0, 0, speedStreet); //MOVIMENTAÇÃO DA PISTA
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MoveStreet : MonoBehaviour {

	[SerializeField]
	private float speedStreet = -1;
	public static bool isDestroyed = false;
	const float MAX_DISTANCE = -100;

	private void Update () {
		gameObject.transform.Translate (0, 0, speedStreet); //MOVIMENTAÇÃO DA PISTA
		Destroy();
	}

	private void Destroy()
	{
		if (gameObject.transform.position.z == MAX_DISTANCE)
		{
			isDestroyed = true;
			Destroy (gameObject);
		}
	}
}

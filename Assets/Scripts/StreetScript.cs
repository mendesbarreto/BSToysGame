using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScript : MonoBehaviour {

    [SerializeField]
    private float speedStreet = -1;
	public static bool isDestroyed = false;
			
	void Update () {
		gameObject.transform.Translate (0, 0, speedStreet); //MOVIMENTAÇÃO DA PISTA
        Destroy();

    }

    void Destroy()
    {
        if (gameObject.transform.position.z == -100)
		{
			isDestroyed = true;
			Destroy (gameObject);
        }
    }
}

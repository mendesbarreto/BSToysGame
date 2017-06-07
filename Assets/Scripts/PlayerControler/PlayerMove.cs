using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	//ATRIBUTOS
	private Rigidbody playerRb;
	[SerializeField]
	private float speedPlayer = 5;
	

	//POSICOES POSSIVEIS
	private readonly float left = -4;
    private readonly float mid = 0;
    private readonly float right = 4.5f;
    private float position;

    private readonly int leftPointer = 0;
    private readonly int midPointer = 1;
    private readonly int rightPointer = 2;
    private int positionPointer;

    //EFEITO CURVA
    private readonly float rangeCurve = 30;
    private Vector3 curve = Vector3.zero;
	private float CurveTimecounter = 0.3f;
	private const int SPEED_ROTACAO = 10;
	private const int SPEED_VOLTA_ROTACAO = 130;

    //SWIPE
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;


    private void Start(){
		LoadResources ();
	}


	private void LoadResources() {
		playerRb = GetComponent<Rigidbody>();
        positionPointer = midPointer;
        position = mid;
    }


	private void Update()
	{
		Controler();
		Move();
		CurveEffect();
	}


	private void Controler()
	{
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                //SWIPE LEFT
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if (positionPointer == rightPointer)
                    {
                        position = mid;
                        positionPointer = midPointer;
                    }
                    else if (positionPointer == midPointer)
                    {
                        position = left;
                        positionPointer = leftPointer;
                    }
                    curve.y = -rangeCurve;
                    CurveTimecounter = 0.3f;
                }
                //SWIPE RIGHT
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if (positionPointer == leftPointer)
                    {
                        position = mid;
                        positionPointer = midPointer;
                    }
                    else if (positionPointer == midPointer)
                    {
                        position = right;
                        positionPointer = rightPointer;
                    }
                    curve.y = rangeCurve;
                    CurveTimecounter = 0.3f;
                }
            }
        }
        /* 
        if (Input.GetKeyDown("d"))
        {
            if (positionPointer == leftPointer)
            {
                position = mid;
                positionPointer = midPointer;
            }
            else if (positionPointer == midPointer)
            {
                position = right;
                positionPointer = rightPointer;
            }
            curve.y = rangeCurve;
            CurveTimecounter = 0.3f;
        }

        if (Input.GetKeyDown("a"))
        {
            if (positionPointer == rightPointer)
            {
                position = mid;
                positionPointer = midPointer;
            }
            else if (positionPointer == midPointer)
            {
                position = left;
                positionPointer = leftPointer;
            }
            curve.y = -rangeCurve;
            CurveTimecounter = 0.3f;
        }*/
    
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

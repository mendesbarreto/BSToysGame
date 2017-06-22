using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {

	//POSICOES POSSIVEIS
	private readonly float left = -15;
	private readonly float mid = 0;
	private readonly float right = 15;
	private float position;

	private readonly int leftPointer = 0;
	private readonly int midPointer = 1;
	private readonly int rightPointer = 2;
	private int positionPointer;

	//SWIPE
	private Vector2 firstPressPos;
	private readonly float speedCam = 8; 

	//PLAYER TYPE
	private const int white = 0;
	private const int red = 1;
	private const int black = 2;

	private void Start()
	{
            LoadResources();
            ChangeCamera();
	}


	private void LoadResources()
	{
        if (MainGameStatus.instance._playerselect == 0)
        {
            positionPointer = midPointer;
            position = mid;
            MainGameStatus.instance._playerselect = white;
        }
        else if (MainGameStatus.instance._playerselect == 1)
        {
            position = left;
            positionPointer = leftPointer;
            MainGameStatus.instance._playerselect = red;
        }
        else
        {
            position = right;
            positionPointer = rightPointer;
            MainGameStatus.instance._playerselect = black;
        }

      
	}

    private void ChangeCamera()
    {
        transform.position = new Vector3(position, transform.position.y, transform.position.z);
    }

	private void Update()
	{
       
		Controler();
		Move();

	}

    /*
	//SWIPE CONTROLER
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
				var secondPressPos = new Vector2(t.position.x, t.position.y);
				var currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				currentSwipe.Normalize();

				//SWIPE LEFT
				if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					if (positionPointer == leftPointer)
					{
						position = mid;
						positionPointer = midPointer;
                         MainGameStatus.instance._playerselect = white;
					}
					else if (positionPointer == midPointer)
					{
						position = right;
						positionPointer = rightPointer;
                         MainGameStatus.instance._playerselect = black;
					}
				}
				//SWIPE RIGHT
				if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					if (positionPointer == rightPointer)
					{
						position = mid;
						positionPointer = midPointer;
                         MainGameStatus.instance._playerselect = white;
					}
					else if (positionPointer == midPointer)
					{
						position = left;
						positionPointer = leftPointer;
                         MainGameStatus.instance._playerselect = red;
					}
				}
			}
		}
	}
	*/
    

    //MOUSE CONTROLER
    private void Controler()
	{

		if (Input.GetMouseButtonDown(0))
		{
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		if (Input.GetMouseButtonUp(0))
		{
			var secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			var currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			currentSwipe.Normalize();

			//SWIPE LEFT
			if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				if (positionPointer == leftPointer)
				{
					position = mid;
					positionPointer = midPointer;
                    MainGameStatus.instance._playerselect = white;
				}
				else if (positionPointer == midPointer)
				{
					position = right;
					positionPointer = rightPointer;
                    MainGameStatus.instance._playerselect = black;
				}
			}

			//SWIPE RIGHT
			if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
			{
				if (positionPointer == rightPointer)
				{
					position = mid;
					positionPointer = midPointer;
                    MainGameStatus.instance._playerselect = white;
				}
				else if (positionPointer == midPointer)
				{
					position = left;
					positionPointer = leftPointer;
                    MainGameStatus.instance._playerselect = red;
				}
			}
		}
	}
    

	private void Move()
	{
		Vector3 final = new Vector3(position, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, final, Time.deltaTime * speedCam);
	}





}

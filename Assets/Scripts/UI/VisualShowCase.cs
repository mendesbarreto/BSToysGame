using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualShowCase : MonoBehaviour {

    //POSICOES POSSIVEIS
    private readonly float left = -15;//-4;
    private readonly float mid = 0;
    private readonly float right = 15;//4.5f;
    private float position;

    private readonly int leftPointer = 0;
    private readonly int midPointer = 1;
    private readonly int rightPointer = 2;
    private int positionPointer;

    //SWIPE
    private Vector2 firstPressPos;
    private readonly float speedCam = 5;

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
            position = mid;
        }
        else if (MainGameStatus.instance._playerselect == 1)
        {
            position = left;
        }
        else
        {
            position = right;
        }
    }

    private void ChangeCamera()
    {
        transform.position = new Vector3(position, transform.position.y, transform.position.z);
    }

}

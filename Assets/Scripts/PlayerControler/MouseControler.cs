using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControler : MonoBehaviour {

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


    private void Start()
    {
        LoadResources();
    }


    private void LoadResources()
    {
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



    private void Move()
    {
        Vector3 final = new Vector3(position, playerRb.transform.position.y, playerRb.transform.position.z);
        playerRb.transform.position = Vector3.Lerp(transform.position, final, Time.deltaTime * speedPlayer);
    }


    private void CurveEffect()
    {
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

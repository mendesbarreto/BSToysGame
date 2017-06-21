using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatus : MonoBehaviour {


    public int _score;
    public int _playerselect;
    public bool _isLive;


    public static MainGameStatus instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    private void LoadResources()
    {
        _score = 0;
        _playerselect = 0;
        _isLive = true;
    }






}




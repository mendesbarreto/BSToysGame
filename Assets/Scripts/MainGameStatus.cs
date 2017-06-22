using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameStatus : MonoBehaviour {

    public bool _playGame;
    public bool _isLive;

    public int _score;
    public int _playerselect;
    

    //Rank
    public int _firstScore;
    public int _secondScore;
    public int _thirtScore;


    public static MainGameStatus instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadResources();
    }

    private void LoadResources()
    {
        _score = 0;
        _playGame = false;
        _isLive = true;

        if (PlayerPrefs.HasKey("PlayerType")) {
            _playerselect = PlayerPrefs.GetInt("PlayerType");
        } else {
            PlayerPrefs.SetInt("PlayerType", _playerselect);
        }

        if (PlayerPrefs.HasKey("PlayerFirst")) {
            _firstScore = PlayerPrefs.GetInt("PlayerFirst");
        } else {
            PlayerPrefs.SetInt("PlayerFirst", _firstScore);
        }
        
        if (PlayerPrefs.HasKey("PlayerSecond")) {
             _secondScore = PlayerPrefs.GetInt("PlayerSecond");
        } else {
            PlayerPrefs.SetInt("PlayerSecond", _secondScore);
        }
        
        if (PlayerPrefs.HasKey("PlayerThird")) {
            _thirtScore = PlayerPrefs.GetInt("PlayerThird");
        } else {
            PlayerPrefs.SetInt("PlayerThird", _thirtScore);
        }

    }


    private void Update()
    {
        if(_playGame == true) {
            LoadPlayerType();
        }


        if (_isLive == false)
        {
            ChangeRanking();      
        }


        

    }

    private void LoadPlayerType()
    {
        Debug.Log(_playGame);
        PlayerPrefs.SetInt("PlayerType", _playerselect);
        _playGame = false;
    }





    private void ChangeRanking()
    {
        if (_score > _firstScore)
        {
            _thirtScore = _secondScore;
            _secondScore = _firstScore;
            _firstScore = _score;

        }
        else if (_score < _firstScore && _score > _secondScore)
        {
            _thirtScore = _secondScore;
            _secondScore = _score;
        }
        else if (_score < _secondScore && _score > _thirtScore)
        {
            _thirtScore = _score;
        }

        Debug.Log(_firstScore);
        Debug.Log(_secondScore);
        Debug.Log(_thirtScore);

        PlayerPrefs.SetInt("PlayerFirst", _firstScore);
        PlayerPrefs.SetInt("PlayerSecond", _secondScore);
        PlayerPrefs.SetInt("PlayerThird", _thirtScore);


        _isLive = true;
    }

}




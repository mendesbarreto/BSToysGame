using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopScoreMenu : MonoBehaviour {

	public Button Menu {
		get {return menu; }
		set { menu = value; }
	}
	[SerializeField]
	private Button menu;


    public Text TxtFirst
    {
        get { return txtFirst; }
        set { txtFirst = value; }
    }
    [SerializeField]
    private Text txtFirst;

    public Text TxtSecond
    {
        get { return txtSecond; }
        set { txtSecond = value; }
    }
    [SerializeField]
    private Text txtSecond;

    public Text TxtThird
    {
        get { return txtThird; }
        set { txtThird = value; }
    }
    [SerializeField]
    private Text txtThird;


    private void Start()
    {
        LoadResources();
        WriteRank();
    }

    private void LoadResources()
    {
        txtFirst = GameObject.Find("First").GetComponent<Text>();
        txtSecond = GameObject.Find("Second").GetComponent<Text>();
        txtThird = GameObject.Find("Third").GetComponent<Text>();
    }


    private void WriteRank()
    {
        txtFirst.text = MainGameStatus.instance._firstScore.ToString();
        txtSecond.text = MainGameStatus.instance._secondScore.ToString();
        txtThird.text = MainGameStatus.instance._thirtScore.ToString();
    }

    public void MenuPress()
	{
		SceneManager.LoadScene("Menu");
	}

}

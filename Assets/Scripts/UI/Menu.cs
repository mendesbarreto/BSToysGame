using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class Menu : MonoBehaviour {

    [SerializeField]
    private Canvas CodeScreen;

    public Button Play {
		get {return play; }
		set { play = value; }
	}
	[SerializeField]
	private Button play;


	public Button Score {
		get {return score; }
		set { score = value; }
	}
	[SerializeField]
	private Button score;


	public Button Code {
		get {return code; }
		set { code = value; }
	}
	[SerializeField]
	private Button code;


	public Button Credits {
		get { return credits; }
		set { credits = value; }
	}
	[SerializeField]
	private Button credits;

	public Button Quit {
		get { return quit; }
		set { quit = value; }
	}
	[SerializeField]
	private Button quit;

    public Text TxtLock
    {
        get { return txtLock; }
        set { txtLock = value; }
    }
    [SerializeField]
    private Text txtLock;

    private void Start()
    {
        LoadResources();
    }
    private void LoadResources()
    {
        txtLock = GameObject.Find("X").GetComponent<Text>();
        if (MainGameStatus.instance._gameStats == 1)
        {
            txtLock.enabled = false;
            Play.enabled = true;
        }
        else
        {
            txtLock.enabled = true;
            Play.enabled = false;
        }
    }

    
    private void Update()
    {
        if (CodeScreen.enabled == false)
        {
            Quit.enabled = true;
            Credits.enabled = true;
            Code.enabled = true;
            Score.enabled = true;
            VerifyUnlock();
        }

       
    }
    

    private void VerifyUnlock()
    {
        if (MainGameStatus.instance._gameStats == 1)
        {
            txtLock.enabled = false;
            Play.enabled = true;
        }
    }

    public void PlayPress()
	{
		SceneManager.LoadScene("MenuSelect");
	}

	public void ScorePress()
	{
		SceneManager.LoadScene("TopScore");
	}

	public void CodePress()
	{
        CodeScreen.enabled = true;
        Quit.enabled = false;
        Credits.enabled = false;
        Code.enabled = false;
        Score.enabled = false;
        Play.enabled = false;
    }

	public void CreditsPress()
	{
		Debug.Log("Credits button");
	}

	public void QuitPress()
	{
		Application.Quit();
	}
}

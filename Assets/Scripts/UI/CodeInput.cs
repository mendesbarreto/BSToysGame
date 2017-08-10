using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeInput : MonoBehaviour {

    [SerializeField]
    private Canvas CodeScreen;

    public Button Submit
    {
        get { return submit; }
        set { submit = value; }
    }
    [SerializeField]
    private Button submit;

    public Button Back
    {
        get { return back; }
        set { back = value; }
    }
    [SerializeField]
    private Button back;

    public InputField Code
    {
        get { return code; }
        set { code = value; }
    }
    [SerializeField]
    private InputField code;

    public Text TxtIncorreto
    {
        get { return txtIncorreto; }
        set { txtIncorreto = value; }
    }
    [SerializeField]
    private Text txtIncorreto;


    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        CodeScreen.enabled = false;
        txtIncorreto = GameObject.Find("txtVerify").GetComponent<Text>();
    }

    public void SubmitPress()
    {
        if(code.text == "reset")
        {
            MainGameStatus.instance._gameStats = 0;
            PlayerPrefs.SetInt("gameStats", MainGameStatus.instance._gameStats);
            PlayerPrefs.DeleteAll();
            txtIncorreto.text = "RESET - ESTADO: " + MainGameStatus.instance._gameStats;

        } else if (code.text == "xj378h7y3")
            {
                MainGameStatus.instance._gameStats = 1;
                code.text = "";
                txtIncorreto.text = "";
                CodeScreen.enabled = false;
            
        } else
            {
                txtIncorreto.text = "CÒDIGO INCORRETO";
            }
    }

    public void BackPress()
    {
        CodeScreen.enabled = false;
        code.text = "";
        txtIncorreto.text = "";
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private Transform m_Transform;
    private GameManager GM;
    private Player player;

    private Button start_Button;
    private Button high_Button;
    private Button closeHigh_Button;
    private Button reset_Button;


    private Text gameScore;
    private Text gameTime;

    private Text lastScore;


	void Awake () {

        m_Transform = gameObject.GetComponent<Transform>();
        GM = GameObject.Find("Main Camera").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();

        start_Button = m_Transform.Find("Start/StartGame").GetComponent<Button>();
        high_Button = m_Transform.Find("Start/HighScore").GetComponent<Button>();
        closeHigh_Button = m_Transform.Find("HighScoreList/Close").GetComponent<Button>();
        reset_Button = m_Transform.Find("End/Button").GetComponent<Button>();

        gameScore = m_Transform.Find("Game/ScoreNum").GetComponent<Text>();
        gameTime = m_Transform.Find("Game/TimeNum").GetComponent<Text>();
        gameTime.text = "10";
        lastScore = m_Transform.Find("End/LastScore").GetComponent<Text>();


        start_Button.onClick.AddListener (GM.GameStart );
        high_Button.onClick.AddListener(GM.ShowHigh);
        closeHigh_Button.onClick.AddListener(GM.CloseHigh);
        reset_Button.onClick.AddListener(GM.GameReset);
	}
	
	void Update () {
        gameScore.text  = GM.gameScore.ToString();

        UpdateTime();

        if(gameTime.text == "0")
        {
            GM.GameOver();
            UIReset();
        }
      
    }

    
    public void UpdateTime()
    {
        if(player.life)
        {
            float  temp = float .Parse(gameTime.text) - Time.deltaTime;
            if (temp >= 0)
            {
                gameTime.text = temp.ToString();
            }
            else
            {
                gameTime.text = "0";
            }
        }
    }
    public void UpdateLastScore()
    {
        lastScore.text = gameScore.text;
    }
    public void UIReset()
    {
        gameTime.text = "10";
    }
    
    


}

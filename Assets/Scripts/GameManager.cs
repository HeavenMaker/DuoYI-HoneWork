using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int gameScore;

    private GameObject startPanel;
    private GameObject gamePanel;
    private GameObject endPanel;
    private GameObject highScorePanel;

    private UI ui;

    private Player player;
    private GameObject prefeb_Gold;
    private Transform goldManager_Transform;

    private Transform grid_Transform;

    private int[] highScoreList=new int[10];
    private Text[] highScoreText ;

    


    void Start () {
        gameScore = 0;

        ui = GameObject.Find("Canvas").GetComponent<UI>();

        startPanel = GameObject .Find("Canvas/Start").gameObject;
        gamePanel = GameObject.Find("Canvas/Game").gameObject;
        endPanel = GameObject.Find("Canvas/End").gameObject;
        highScorePanel = GameObject.Find("Canvas/HighScoreList").gameObject;

        player = GameObject.Find("Player").GetComponent<Player>();

        prefeb_Gold = Resources.Load("Gold")as GameObject ;
        goldManager_Transform = GameObject.Find("GoldManager").GetComponent<Transform>();

        grid_Transform = GameObject.Find("Canvas/HighScoreList/Image/Grid").GetComponent<Transform>();
        highScoreText = grid_Transform.GetComponentsInChildren<Text>();

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.GetInt(i.ToString(), 1);
        }
        



        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        highScorePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update () {

             
    }

    public void GameStart()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);

        player.life = true;
        gameScore = 0;
        InvokeRepeating("CreateGold", 1.0f, 1.0f);
    }
    public void GameOver()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        ui.UpdateLastScore();
        UpdateHighScore(gameScore);
        player.life = false;
        CancelInvoke("CreateGold");
    }
    public void GameReset()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        DestroyGold();
        player.gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }

    public void  CreateGold()
    {
        Vector3 pos = new Vector3(Random.Range(-8.0f, 8.0f), 0.5f, Random.Range(-8.0f, 8.0f));
        GameObject.Instantiate(prefeb_Gold, pos, Quaternion.identity, goldManager_Transform);
    }
    public void DestroyGold()
    {
        Transform[] list= goldManager_Transform.GetComponentsInChildren<Transform>();
        for (int i = 1; i < list.Length ; i++)
        {
            GameObject.Destroy(list[i].gameObject);
        }
    }
    public void ShowHigh()
    {
        ShowHighScore();
            highScorePanel.SetActive(true);
        
    }
    public void CloseHigh()
    {
        highScorePanel.SetActive(false);
    }

    private void UpdateHighScore(int gameScore)
    {
        List<int> temp = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            temp.Add(PlayerPrefs.GetInt(i.ToString()));
        }
        temp.Add(gameScore);

        for (int i = 0; i < temp.Count; i++)
        {
            for (int j = i+1; j < temp.Count ; j++)
            {
                if (temp[i] < temp[j])
                {
                    int a = temp[i];
                    temp[i] = temp[j];
                    temp[j] = a;
                }
            }
        }
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), temp[i]);
        }
    }
    private void ShowHighScore()
    {
        for (int i = 0; i < 10; i++)
        {
            highScoreText[i].text = PlayerPrefs.GetInt(i.ToString()).ToString();
        }
    }

    
}

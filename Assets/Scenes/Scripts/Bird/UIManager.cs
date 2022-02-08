using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static  UIManager Instance;
    public enum EnStatus
    {
        Ready,
        Started,
        Over
    }
    public EnStatus status;
    public EnStatus Status
    {
        get { return status; }
        set { status = value; 
              UpStatus();
        }
    }


    private Button startButton;
    private Button restartButton;
    public GameObject readyPanel;
    public GameObject gameingPanel;
    public GameObject overPanel;
    public Text Score;
    public Text ThisTimeScore;
    public Text BestScore;
    public PipleManager pipleManager;
    public PlayerController Player;

    private int ScoreNum = 0;
    void Awake()
    {
        Instance = this;
        startButton = transform.Find("ReadyPanel/StartButton").gameObject.GetComponent<Button>();
        restartButton = transform.Find("OverPanel/ReStartButton").gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(ReStartGame);
        this.Status = EnStatus.Ready;

    }
    private int Scores
    {
        get { return ScoreNum; }
        set { this.ScoreNum = value;
            this.Score.text = ScoreNum.ToString();
            this.ThisTimeScore.text = ScoreNum.ToString();
            
        }
    }
    void StartGame()
    {
        pipleManager.StartRun();
        this.Status = EnStatus.Started;
        Player.Fly();
    }
    void ReStartGame()
    {
        this.Status = EnStatus.Ready;
        this.Scores = 0;
        Player.Init();
    }
    public void UpStatus()
    {
        readyPanel.gameObject.SetActive(this.status == EnStatus.Ready);
        gameingPanel.gameObject.SetActive(this.status == EnStatus.Started);
        overPanel.gameObject.SetActive(this.status == EnStatus.Over);
    }

    public void AddScore()
    {
        this.Scores++;
    }

    public void GameOver()
    {
        this.Status = EnStatus.Over;
        this.BestScore.text = ScoreManager.Instance.Comper(this.Scores).ToString();
    }
}

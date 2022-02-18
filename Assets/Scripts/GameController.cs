using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Starter starter;


    public Text scoreTextLeft;
    public Text scoreTextRight;
    private int scoreleft = 0;
    private int scoreright = 0;
    private bool started = false;

    private BallController ballcontroller;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.ballcontroller = this.ball.GetComponent<BallController>();
        this.startPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.started)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starter.StartCountdown();
        }

    }
    public void ScoreGoalLeft()
    {
        Debug.Log("Goooooooooooooooooool Sað");
        scoreright++;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("Goooooooooooooooooool Sol");
        scoreleft++;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreleft.ToString();
        this.scoreTextRight.text = this.scoreright.ToString();
    }

    private void ResetBall()
    {
        this.ballcontroller.Stop();
        this.ball.transform.position = this.startPosition;
        this.starter.StartCountdown();
    }

    public void StartGame()
    {
        this.ballcontroller.Go();
    }
}

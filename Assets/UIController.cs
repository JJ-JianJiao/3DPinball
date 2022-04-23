using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIController : MonoBehaviour
{
    public bool extraLife = false;
    GameObject gamestate;
    GameObject ball;
    GameStateController gameStateController;
    public bool SetText;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        gamestate = GameObject.FindGameObjectsWithTag("GameState")[0];
        gameStateController = gamestate.GetComponent<GameStateController>();
        SetText = true;
        //if (this.name.Equals("GetPlayerName")) {
        //    this.gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.name.Equals("GetPlayerName"))
        //{
        //    if (ball.GetComponent<BallController>().life <= 0)
        //    {
        //        this.gameObject.;
        //    }
        //    else {
        //        this.gameObject.SetActive(false);
        //    }

        //}
        if (this.name.Equals("LifeText"))
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Life: " + ball.GetComponent<BallController>().life;
        }
        if (this.name.Equals("ScoreText")) 
        {
            this.GetComponent<UnityEngine.UI.Text>().color = new Color(154/ 255f, 11 / 255f, 17/ 255f);
            this.GetComponent<UnityEngine.UI.Text>().text = "Score: " + ball.GetComponent<BallController>().score;
        }
        if (this.name.Equals("OverMenu") && ball.GetComponent<BallController>().life <=0) 
        {
            if (SetText)
            {
                this.GetComponent<UnityEngine.UI.Text>().color = new Color(233 / 255f, 34 / 255f, 70 / 255f);
                this.GetComponent<UnityEngine.UI.Text>().fontSize = 40;


                if (gameStateController.topTenScore.Count == 0)
                {
                    this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour Get\nHighest Score\n" + ball.GetComponent<BallController>().score;
                    gameStateController.topTenScore.Add(ball.GetComponent<BallController>().score);
                    string nameStr = GameObject.Find("GetPlayerName").GetComponent<UnityEngine.UI.InputField>().text;
                    gameStateController.names.Add(nameStr);

                }
                else
                {
                    if (gameStateController.topTenScore.Count == 10) {
                        if (gameStateController.topTenScore[gameStateController.topTenScore.Count - 1] >= ball.GetComponent<BallController>().score)
                        {
                            this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                        }
                        else {
                            this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                            gameStateController.topTenScore[gameStateController.topTenScore.Count - 1] = ball.GetComponent<BallController>().score;
                            string nameStr = GameObject.Find("GetPlayerName").GetComponent<UnityEngine.UI.InputField>().text;
                            gameStateController.topTenScore.Sort((x,y)=>-x.CompareTo(y));
                            int i = 0;
                            for (; i < gameStateController.topTenScore.Count; i++) {
                                if (ball.GetComponent<BallController>().score == gameStateController.topTenScore[i]) {
                                    break;
                                }
                            }
                            gameStateController.names.Insert(i, nameStr);
                        }
                    }
                    else if(gameStateController.topTenScore.Count < 10)
                    {
                        this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                        gameStateController.topTenScore.Add(ball.GetComponent<BallController>().score);
                        string nameStr = GameObject.Find("GetPlayerName").GetComponent<UnityEngine.UI.InputField>().text;
                        gameStateController.names.Add(nameStr);
                        //gameStateController.topTenScore.Add(ball.GetComponent<BallController>().score);
                        gameStateController.topTenScore.Sort((x, y) => -x.CompareTo(y));
                    }

                    //if (gameStateController.topTenScore[gameStateController.topTenScore.Count - 1] >= ball.GetComponent<BallController>().score)
                    //{
                    //    if (gameStateController.topTenScore.Count == 10)
                    //    {
                    //        this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                    //    }
                    //    else {
                    //        this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                    //        gameStateController.topTenScore.Add(ball.GetComponent<BallController>().score);
                    //    }
                    //}
                    //else
                    //{
                    //    gameStateController.topTenScore[gameStateController.topTenScore.Count - 1] = ball.GetComponent<BallController>().score;
                    //    this.GetComponent<UnityEngine.UI.Text>().text = "Game Over\n\nYour scoure\n" + ball.GetComponent<BallController>().score;
                    //    gameStateController.topTenScore.Sort();
                    //}

                }
                this.GetComponent<UnityEngine.UI.Text>().text += "\nPlay again?\nY/N";
                SetText = false;
            }

            if (Input.GetKeyDown(KeyCode.Y)) {
                this.GetComponent<UnityEngine.UI.Text>().text = "";
                ball.GetComponent<BallController>().life = 3;
                //ball.GetComponent<BallController>().life = 1;
                ball.GetComponent<BallController>().score = 0;
                SetText = true;
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                ball.GetComponent<BallController>().life = 3;
                //ball.GetComponent<BallController>().life = 1;
                SceneManager.LoadScene("StartMenu");
                SetText = true;
                gamestate.GetComponent<GameStateController>().SaveHighScore();
            }
        }
    }
}

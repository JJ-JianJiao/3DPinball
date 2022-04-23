using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionControlle : MonoBehaviour
{
    public bool SelectOne;
    public bool SelectTwo;
    public bool SelectThree;
    private string start;
    private string HighScore;
    private string Quit;
    public int selectedIndex;
    GameObject selectOne;
    GameObject selectTwo;
    GameObject selectThree;
    GameObject displayTopTen;
    GameObject gamestate;
    GameStateController gameStateController;
    public bool GetTopTen;
    private bool ShowTopTen;
    // Start is called before the first frame update
    void Start()
    {
        GetTopTen = false;
        ShowTopTen = false;
        SelectOne = true;
        SelectTwo = false;
        SelectThree = false;
        start = "Start";
        HighScore = "High Score";
        Quit = "Quit";
        selectedIndex = 1;
        selectOne = GameObject.Find("StartOp");
        selectTwo = GameObject.Find("HighScoreOp");
        selectThree = GameObject.Find("QuitOp");
        displayTopTen = GameObject.Find("TopTenPlayers");
        gamestate = GameObject.Find("GameState");
        //gameStateController = gameObject.GetComponent<GameStateController>();
        //if (this.name.Equals("TopTenPlayers")) { 
        //    gameStateController.LoadHighScore();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowTopTen && this.name.Equals("TopTenPlayers"))
        {
            if (!GetTopTen)
            {

                gamestate.GetComponent<GameStateController>().LoadHighScore();
                List<int> scores = gamestate.GetComponent<GameStateController>().topTenScore;
                List<string> playername = gamestate.GetComponent<GameStateController>().names;
                for (int i = 0; i < scores.Count; i++)
                {
                    this.GetComponent<UnityEngine.UI.Text>().text += ((playername[i] == "") ? "Player" + (i + 1).ToString() : playername[i]) + ": " + scores[i].ToString() + "\n";
                }
                GetTopTen = true;
            }

        }

        if (this.name.Equals("StartOp"))
        {
            if (SelectOne)
                this.GetComponent<UnityEngine.UI.Text>().text = "-- " + start + " --";
            else
            {
                this.GetComponent<UnityEngine.UI.Text>().text = start;
            }
        }
        if (this.name.Equals("HighScoreOp"))
        {
            if (SelectTwo)
                this.GetComponent<UnityEngine.UI.Text>().text = "-- " + HighScore + " --";
            else
            {
                this.GetComponent<UnityEngine.UI.Text>().text = HighScore;
            }
        }
        if (this.name.Equals("QuitOp"))
        {
            if (SelectThree)
                this.GetComponent<UnityEngine.UI.Text>().text = "-- " + Quit + " --";
            else
            {
                this.GetComponent<UnityEngine.UI.Text>().text = Quit;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectedIndex == 1)
            {
                SelectThree = true;
                SelectTwo = false;
                SelectOne = false;
                selectedIndex = 3;
            }
            else if (selectedIndex == 2)
            {
                SelectThree = false;
                SelectTwo = false;
                SelectOne = true;
                selectedIndex = 1;
            }
            else if (selectedIndex == 3)
            {
                SelectThree = false;
                SelectTwo = true;
                SelectOne = false;
                selectedIndex = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedIndex == 1)
            {
                SelectThree = false;
                SelectTwo = true;
                SelectOne = false;
                selectedIndex = 2;
            }
            else if (selectedIndex == 2)
            {
                SelectThree = true;
                SelectTwo = false;
                SelectOne = false;
                selectedIndex = 3;
            }
            else if (selectedIndex == 3)
            {
                SelectThree = false;
                SelectTwo = false;
                SelectOne = true;
                selectedIndex = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedIndex == 1)
            {
                SceneManager.LoadScene("MainGame");
            }
            else if (selectedIndex == 2)
            {
                selectOne.SetActive(false);
                selectTwo.SetActive(false);
                selectThree.SetActive(false);
                displayTopTen.SetActive(true);

                ShowTopTen = true;
            }
            else if (selectedIndex == 3)
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectOne.SetActive(true);
            selectTwo.SetActive(true);
            selectThree.SetActive(true);
            displayTopTen.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class GameStateController : MonoBehaviour
{
    public List<string> names;
    public List<int> topTenScore;

    //public Dictionary<string, int> topTenScores;
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        if (names == null || topTenScore == null)
        {
            names = new List<string>();
            topTenScore = new List<int>();
        }
        //if (topTenScores == null) {
        //    topTenScores = new Dictionary<string, int>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //int a = 0;
    }

    private void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("GameState");
        if (gameObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SaveHighScore() {
        string dataPath = Path.Combine(Application.persistentDataPath, "Score.txt");
        string jsonString = JsonUtility.ToJson(this);

        using (StreamWriter streamWriter = File.CreateText(dataPath)) {
            streamWriter.Write(jsonString);
        }
    }

    public void LoadHighScore() { 
        string dataPath = Path.Combine(Application.persistentDataPath, "Score.txt");

        using (StreamReader streamReader = File.OpenText(dataPath)) {
            string jsonString = streamReader.ReadToEnd();

            GameStateController gameStateSaved = new GameStateController();
            JsonUtility.FromJsonOverwrite(jsonString, gameStateSaved);
            this.names = gameStateSaved.names;
            this.topTenScore = gameStateSaved.topTenScore;
            //this.topTenScores = gameStateSaved.topTenScores;
        }

    }
}

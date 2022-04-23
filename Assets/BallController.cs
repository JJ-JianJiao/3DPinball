using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int life;
    //private bool activeGame;
    public float intensity;
    public int score;

    public GameObject getPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        //activeGame = false;
        intensity = 0;
        life = 3;
        //life = 1;
        score = 0;
        getPlayerName = GameObject.Find("GetPlayerName");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.life == 0)
        {
            getPlayerName.SetActive(true);
        }
        else
        {
            getPlayerName.SetActive(false);
        }

        if (intensity != 0) {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1 * intensity));
            intensity = 0;
        }
    }
}

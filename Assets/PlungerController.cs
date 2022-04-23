using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerController : MonoBehaviour
{
    GameObject ball;
    Vector3 ballPositon;
    private float speed;
    private Vector3 OriginalPositon;
    Vector3 ballOriginPositon;
    private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        speed = -1;
        OriginalPositon = this.gameObject.transform.position;
        ball = GameObject.Find("Ball").gameObject;
        ballOriginPositon = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ballPositon = ball.transform.position;
        //if (Input.GetKey(KeyCode.Space)) {
        if (Input.GetKey(KeyCode.Space) && ball.GetComponent<BallController>().life > 0) {
            if(this.transform.position.y >= -6.94-2) { 
                this.gameObject.transform.Translate(new Vector3(0, speed * 1 * Time.deltaTime));
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) ) {
            intensity = Mathf.Abs(this.transform.position.y - OriginalPositon.y);
            this.transform.position = OriginalPositon;
            if(ballPositon.x >= ballOriginPositon.x -0.5 && ballPositon.x <= ballOriginPositon.x + 0.5 && ballPositon.y < ballOriginPositon.y+0.5 && ballPositon.y >= ballOriginPositon.y - 0.5) { 
                ball.GetComponent<BallController>().intensity = this.intensity * 500;
            }
        }
    }
}

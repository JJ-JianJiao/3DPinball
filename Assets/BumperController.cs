using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private int changeColor;
    private float changeColorTimer = 0;
    private bool getHit = false;
    private float changeColorTimerDur = 1f;

    private void Update()
    {
        if (getHit)
        {
            changeColorTimer += Time.deltaTime;
        }


        if (changeColor % 4 == 1)
        {
            if (changeColorTimer < changeColorTimerDur)
            {
                this.transform.GetComponent<Renderer>().material.color = Color.green;
            }
            else {
                this.transform.GetComponent<Renderer>().material.color = Color.white;
                getHit = false;
                
            }
        }
        else if (changeColor % 4 == 2)
        {
            if (changeColorTimer < changeColorTimerDur)
            {
                this.transform.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                this.transform.GetComponent<Renderer>().material.color = Color.white;
                getHit = false;
            }
        }
        else if (changeColor % 4 == 3)
        {
            if (changeColorTimer < changeColorTimerDur)
            {
                this.transform.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                this.transform.GetComponent<Renderer>().material.color = Color.white;
                getHit = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        changeColor++;
        getHit = true;
        collision.gameObject.GetComponent<BallController>().score += 70;
        changeColorTimer = 0;
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(60 * collision.relativeVelocity*-1);
    }
}

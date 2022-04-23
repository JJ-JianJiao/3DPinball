using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickoutHoleController : MonoBehaviour
{
    private float stopTimer;
    private GameObject ball;
    private Vector2 outSidePosition;
    private Vector3 relativeVeclocity;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = 3;
        ball = GameObject.Find("Ball");
        //outSidePosition = new Vector2(10000, -10000);
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        stopTimer += Time.deltaTime;
        if (stopTimer > 3 && !active) {
            ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            ball.gameObject.GetComponent<Rigidbody2D>().AddForce(relativeVeclocity * -4);
        }
        if (stopTimer > 4) {
            active = true;
        }


        //if (stopTimer > 5)
        //{
        //    ball.transform.position = this.transform.position;
        //    ball.gameObject.GetComponent<Rigidbody2D>().AddForce(60 * relativeVeclocity * -1);
        //    ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //}
        //if (stopTimer > 6) {
        //    active = false;
        //}

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        //if (!active) { 
        //    stopTimer = 0;
        //    //collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        //    //collider.gameObject.GetComponent<Rigidbody2D>().velocity.
        //    relativeVeclocity = collider.relativeVelocity;
        //    collider.gameObject.transform.position = outSidePosition;
        //    active = true;
        //}
        if (active) {
            stopTimer = 0;
            collider.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collider.gameObject.transform.position = this.transform.position;
            relativeVeclocity = collider.relativeVelocity;
            active = false;
            collider.gameObject.GetComponent<BallController>().score += 500;
        }
    }
}

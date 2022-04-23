using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopFiveController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag.Equals("topFive")) { 
            collision.gameObject.GetComponent<BallController>().score += 100;
            Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce( collision.relativeVelocity * -1);
        }
        if (this.gameObject.tag.Equals("TopBlockTag")) {
            collision.gameObject.GetComponent<BallController>().score += 300;
        }
    }
}

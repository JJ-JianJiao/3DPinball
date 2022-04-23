using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomNeedle : MonoBehaviour
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
        collision.gameObject.GetComponent<BallController>().score += 300;
        Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(60 * collision.relativeVelocity * -1);
    }
}

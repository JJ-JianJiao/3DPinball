using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour
{
    private bool active;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5) {
            this.transform.localScale = new Vector3(0.6f, 1f, 1);
            active = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active) {
            timer = 0;
            this.transform.localScale = new Vector3(0.6f, 0.5f, 1);
            collision.gameObject.GetComponent<BallController>().score += 600;
            active = false;
        }
    }
}

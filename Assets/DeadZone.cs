using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(Wait(collider));
    }

    IEnumerator Wait(Collider2D collider) {
        yield return new WaitForSeconds(2);

        collider.transform.position = GameObject.Find("BallSpawnPoint").gameObject.transform.position;
        collider.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if(collider.GetComponent<BallController>().life > 0) { 
            collider.GetComponent<BallController>().life--;
            if (collider.GetComponent<BallController>().life == 0) {
                int score = collider.GetComponent<BallController>().score/100%100;
                if (!GameObject.Find("LifeText").GetComponent<UIController>().extraLife && score == Random.Range(10, 99)) {
                    collider.GetComponent<BallController>().life = 3;
                    GameObject.Find("LifeText").GetComponent<UIController>().extraLife = true;
                }
            }
        }
    }
}

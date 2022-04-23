using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public bool rightFlipper;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name.Equals("RightFlipper")) {
            rightFlipper = true;
        }
        else if (this.name.Equals("LeftFlipper"))
        {
            rightFlipper = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if ((rightFlipper && Input.GetKey(KeyCode.RightAlt)) || (!rightFlipper && Input.GetKey(KeyCode.LeftAlt))){
            GetComponent<HingeJoint2D>().useMotor = true;
        }
        else 
        {
            GetComponent<HingeJoint2D>().useMotor = false;    
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    float inputX;

    public GameObject target;//the target object
    private float speedMod = 5.0f;//a speed modifier
    float smooth = 5.0f;
    private Vector3 point;//the coord to the point where the camera looks at

    void Start()
    {//Set up things on the start method
        
    }

    //void Update()
    //{//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
      //  transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    //}

    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.Find("GolfBall(Clone)");
            point = target.transform.position;//get target's coords
            transform.LookAt(point);//makes the camera look to it
        }

        //rotate the camera around the ball if the user hits the L and R arrow keys
        inputX = Input.GetAxisRaw("Horizontal");

        if (inputX > 0)
            transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
        else if (inputX < 0)
            transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * -speedMod);
        
    }
}

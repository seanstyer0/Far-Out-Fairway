using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static Ball S;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        rb = S.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.sleepThreshold = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit: " + collision.gameObject.name);
        string tag = collision.gameObject.tag;
        if (tag == "SandTrap")
        {
            RunGame.inSandTrap = true;
            print("In sand Trap");
        }
        else if (tag == "Water")
        {
            RunGame.inWater = true;
            RunGame.S.BallFellInWater();
            print("Fell in water");
        }
        else if(tag == "Tee")
        {

        }

        else if (tag == "OutOfBounds")
        {
            RunGame.outOfBounds = true;
            RunGame.S.BallFellOutOfBounds();
            print("Went out of bounds");
        }
    }
}

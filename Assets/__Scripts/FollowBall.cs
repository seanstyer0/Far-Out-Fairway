using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public static FollowBall S;
    public GameObject ball;
    public Transform camTransform;
    public GameObject arrow;
    public GameObject arrow2;
    public GameObject arrow3;
    public MeshRenderer arrowRenderer;
    public MeshRenderer arrowRenderer2;
    public MeshRenderer arrowRenderer3;

    public Vector3 pos;
    //float distance = 1.0f; // distance from ball
    private float speedMod = 5.0f;//rotate speed modifier
    float inputX;

    static Vector3 offset;

    void Start()
    {
        //camTransform = this.transform;
    }

    void Update()
    {
        arrowRenderer.enabled = true;
        arrowRenderer2.enabled = true;
        arrowRenderer3.enabled = true;
    }

    public static void CalculateOffset(Vector3 position)
    {
        offset = Camera.main.transform.position - position;
    }

    private void LateUpdate()
    {
        //rotate the camera around the ball if the user hits the L and R arrow keys
        inputX = Input.GetAxisRaw("Horizontal");
        ball = GameObject.Find("GolfBall(Clone)");
        arrow = GameObject.Find("Arrow");
        arrow2 = GameObject.Find("Arrow (1)");
        arrow3 = GameObject.Find("Arrow (2)");
        arrowRenderer = arrow.GetComponent<MeshRenderer>();
        arrowRenderer2 = arrow2.GetComponent<MeshRenderer>();
        arrowRenderer3 = arrow3.GetComponent<MeshRenderer>();

        pos = ball.transform.position;
        if (Ball.S.rb.IsSleeping() && !RunGame.isTeleporting)
        {
            if (inputX > 0)
            {
                transform.RotateAround(pos, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
                CalculateOffset(pos);
            }
            else if (inputX < 0)
            {
                transform.RotateAround(pos, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * -speedMod);
                CalculateOffset(pos);
            }
        }
        else
        {
            Camera.main.transform.position = ball.transform.position + offset;
            arrowRenderer.enabled = false;
            arrowRenderer2.enabled = false;
            arrowRenderer3.enabled = false;
        }
    }
}

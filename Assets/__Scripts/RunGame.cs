using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ClubState
{
    driver,     //most power, shoots up and forward
    iron,       //less power, shoots up and forward
    putter      //least power, only shoots forward (ball gets no air)
}

public enum BallState
{
    waiting,    //waiting to be hit
    flying,     //has been hit
    loading,    //club is being loaded
    inHole      //ball in hole, round is over
}

public class RunGame : MonoBehaviour
{
    public static RunGame S;

    public GameObject ball;
    public GameObject ballGO;
    public GameObject clubGO;
    

    public static int level = 1;                               //the current level
    public ClubState currClub = ClubState.driver;   //default current club to a driver
    public BallState state = BallState.waiting;     //default to no user control

    public static List<int> scores = new List<int>();

    public float ballPower;
    public float ballPowerIncrement = 0.25f;
    public bool gainingPower = true;
    public bool shotReady;
    public bool levelComplete = false;              //has the user beaten the game
    public int shotCount = 0;
    public static bool inSandTrap = false;
    public static bool inWater = false;
    public static bool outOfBounds = false;
    public Vector3 previousShot;
    public static bool isTeleporting = false;

    //UI elements
    public GameObject outerPanelGO;
    public GameObject innerPanelGO;
    public GameObject scoreboardGO;
    public GameObject driver;
    public GameObject iron;
    public GameObject putter;
    public GameObject controls;
    public GameObject canvas;

    //map UI elements
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject map5;
    public GameObject map6;
    public GameObject map7;
    public GameObject map8;
    public GameObject map9;

    //scoreboard UI elements
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    public Text score6;
    public Text score7;
    public Text score8;
    public Text score9;
    public Text totalScore;

    //Out of bounds and in water UI elements
    public Text alertText;


    RectTransform innerPannelRT;

    Vector3 originalPosition; //original position of the innerPannel;


    // Start is called before the first frame update
    void Start()
    {
        S = this;

        if(scores.Count == 0)
            scores.Add(-1); //fill the level 0 slot

        if (scoreboardGO != null)
            scoreboardGO.SetActive(false);
        StartLevel();

        innerPannelRT = innerPanelGO.transform.GetComponent<RectTransform>();
        originalPosition = innerPannelRT.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the ball isn't sleeping, make sure its ready for a second shot
        if (!shotReady && ballGO.GetComponent<Rigidbody>().IsSleeping())
        {
            //FollowBall.ResetCam();
            shotReady = true;
            state = BallState.waiting;
            //turn off gravity, reset ball rotation to 0, spawn club, bring back gravity
            Ball.S.rb.useGravity = false;
            Ball.S.transform.rotation = Quaternion.Euler(0, 0, 0);
            //spawn correct club
            switch (currClub)
            {
                case ClubState.driver:
                    driver.SetActive(true);
                    break;
                case ClubState.iron:
                    iron.SetActive(true);
                    break;
                case ClubState.putter:
                    putter.SetActive(true);
                    break;
            }

            
        }
        CheckScoreboard();
        CheckControls();
        CheckMap();
        CheckClubSwitch();
        CheckBallPowerUp();

        if (S.levelComplete)
        {
            EndLevel();
        }
    }

    public void CheckMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            switch (level)
            {
                case 1:
                    map1.SetActive(true);
                    break;
                case 2:
                    map2.SetActive(true);
                    break;
                case 3:
                    map3.SetActive(true);
                    break;
                case 4:
                    map4.SetActive(true);
                    break;
                case 5:
                    map5.SetActive(true);
                    break;
                case 6:
                    map6.SetActive(true);
                    break;
                case 7:
                    map7.SetActive(true);
                    break;
                case 8:
                    map8.SetActive(true);
                    break;
                case 9:
                    map9.SetActive(true);
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            switch (level)
            {
                case 1:
                    map1.SetActive(false);
                    break;
                case 2:
                    map2.SetActive(false);
                    break;
                case 3:
                    map3.SetActive(false);
                    break;
                case 4:
                    map4.SetActive(false);
                    break;
                case 5:
                    map5.SetActive(false);
                    break;
                case 6:
                    map6.SetActive(false);
                    break;
                case 7:
                    map7.SetActive(false);
                    break;
                case 8:
                    map8.SetActive(false);
                    break;
                case 9:
                    map9.SetActive(false);
                    break;
            }
        }
    }

    public void CheckControls()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            controls.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            controls.SetActive(false);
        }
    }

    public void CheckScoreboard()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            print("scoreboard active");
            int total = 0;

            for(int i = 0; i < scores.Count; i++)
            {
                if(scores[i] != null)
                {
                    switch (i)
                    {
                        case 1:
                            score1.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 2:
                            score2.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 3:
                            score3.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 4:
                            score4.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 5:
                            score5.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 6:
                            score6.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 7:
                            score7.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 8:
                            score8.text = scores[i].ToString();
                            total += scores[i];
                            break;
                        case 9:
                            score9.text = scores[i].ToString();
                            total += scores[i];
                            break;
                    }
                }
                if (total != 0)
                    totalScore.text = total.ToString();
            }
            scoreboardGO.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            scoreboardGO.SetActive(false);
        }
    }

    public void CheckBallPowerUp()
    {
        if (state == BallState.waiting && Input.GetKeyDown(KeyCode.Space) && !isTeleporting)
        {
            //change ball state to loading
            state = BallState.loading;
            ballPower = 0;
            //Set the UI objects as active
            outerPanelGO.SetActive(true);
            innerPanelGO.SetActive(true);
        }

        if (state == BallState.loading && Input.GetKeyUp(KeyCode.Space) && !isTeleporting)
        {
            state = BallState.flying;
            

            //grab the current club type and set the force divider accordingly
            float forceDiv = 4;
            switch (currClub)
            {
                case ClubState.driver:
                    SoundManagerScript.PlaySound("golfSwing");
                    break;
                case ClubState.iron:
                    SoundManagerScript.PlaySound("golfSwing");
                    forceDiv *= 1.5f;
                    break;
                case ClubState.putter:
                    SoundManagerScript.PlaySound("golfPutt");
                    forceDiv *= 2f;
                    break;

            }

            //Grab the power and apply it to the ball
            Vector3 hitDirection = Camera.main.transform.forward;
            //ball travels upwards for the driver and iron
            if(currClub != ClubState.putter)
                hitDirection.y = 1.2f;

            //Check to see if you are in a sand trap
            if (inSandTrap)
            {
                forceDiv *= 2;
                hitDirection.y = 3f;
                inSandTrap = false;
            }

            //Store the previous location
            previousShot = Ball.S.transform.position;

            //Hit the ball
            Ball.S.rb.velocity = hitDirection * (ballPower / forceDiv);

            shotCount++;

            if(scores.Count <= level)
            {
                scores.Add(shotCount);
            }
            else
            {
                scores[level]++;
            }

            //get rid of the club
            switch(currClub){
                case ClubState.driver:
                    driver.SetActive(false);
                    break;
                case ClubState.iron:
                    iron.SetActive(false);
                    break;
                case ClubState.putter:
                    putter.SetActive(false);
                    break;
            }

            Ball.S.rb.useGravity = true;

            //the ball isn't shot ready while in the air
            shotReady = false;

            //Reset the size and position of the inner pannel
            innerPannelRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
            Vector3 temp = innerPannelRT.position;
            temp.y -= (ballPower / 2) * canvas.GetComponent<RectTransform>().localScale.y;
            innerPannelRT.SetPositionAndRotation(temp, Quaternion.identity);

            //Reset
            ballPower = 0;
            outerPanelGO.SetActive(false);
            innerPanelGO.SetActive(false);
        }


        if (state == BallState.loading && !isTeleporting)
        {
            if (gainingPower && ballPower < 100)
            {
                ballPower += ballPowerIncrement;
                innerPannelRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ballPower);
                innerPannelRT.ForceUpdateRectTransforms();

                Vector3 pannelPos = innerPannelRT.position;
                pannelPos.y += (ballPowerIncrement / 2) * canvas.GetComponent<RectTransform>().localScale.y;
                innerPannelRT.SetPositionAndRotation(pannelPos, Quaternion.identity);

                //print(ballPower);
            }
            else if (!gainingPower && ballPower > 0)
            {
                ballPower -= ballPowerIncrement;
                innerPannelRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ballPower);
                innerPannelRT.ForceUpdateRectTransforms();

                Vector3 pannelPos = innerPannelRT.position;
                pannelPos.y -= (ballPowerIncrement / 2) * canvas.GetComponent<RectTransform>().localScale.y;
                innerPannelRT.SetPositionAndRotation(pannelPos, Quaternion.identity);

                //print(ballPower);
            }

            if (ballPower <= 0)
            {
                gainingPower = true;
            }
            if (ballPower >= 100)
            {
                gainingPower = false;
            }
        }
    }

    public void CheckClubSwitch()
    {
        if(state == BallState.waiting && Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("switching clubs");
            switch (currClub)
            {
                case ClubState.driver:
                    currClub = ClubState.putter;
                    driver.SetActive(false);
                    putter.SetActive(true);
                    print("driver to putter");
                    break;
                case ClubState.iron:
                    currClub = ClubState.driver;
                    iron.SetActive(false);
                    driver.SetActive(true);
                    print("iron to driver");
                    break;
                case ClubState.putter:
                    currClub = ClubState.iron;
                    putter.SetActive(false);
                    iron.SetActive(true);
                    print("putter to iron");
                    break;
            }
        }

        if (state == BallState.waiting && Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("switching clubs");
            switch (currClub)
            {
                case ClubState.driver:
                    currClub = ClubState.iron;
                    driver.SetActive(false);
                    iron.SetActive(true);
                    print("driver to iron");
                    break;
                case ClubState.iron:
                    currClub = ClubState.putter;
                    iron.SetActive(false);
                    putter.SetActive(true);
                    print("iron to putter");
                    break;
                case ClubState.putter:
                    currClub = ClubState.driver;
                    putter.SetActive(false);
                    driver.SetActive(true);
                    print("putter to driver");
                    break;
            }
        }
    }


    //start a given level
    public void StartLevel()
    {
        shotReady = false;
        //instantiate the ball based on the current level
        print(level);
        switch (level)
        {
            case 1:
                ballGO = Instantiate(ball, new Vector3(0f, 1.56f, 19f), Quaternion.identity);
                break;
            case 2:
                ballGO = Instantiate(ball, new Vector3(2.35f, 1.57f, 10.93f), Quaternion.identity);
                break;
            case 3:
                ballGO = Instantiate(ball, new Vector3(13.186f, 7.4753f, 2.5424f), Quaternion.identity);
                break;
            case 4:
                ballGO = Instantiate(ball, new Vector3(-0.025f, 1.571f, 19f), Quaternion.identity);
                break;
            case 5:
                ballGO = Instantiate(ball, new Vector3(0.004f, 1.5661f, 19.042f), Quaternion.identity);
                break;
            case 6:
                ballGO = Instantiate(ball, new Vector3(-0.007f, 1.5702f, 19.062f), Quaternion.identity);
                break;
            case 7:
                ballGO = Instantiate(ball, new Vector3(0.022f, 1.3198f, 19.045f), Quaternion.identity);
                break;
            case 8:
                ballGO = Instantiate(ball, new Vector3(0.007f, 1.317f, 19.146f), Quaternion.identity);
                break;
            case 9:
                ballGO = Instantiate(ball, new Vector3(-0.007f, 1.2834f, 19.134f), Quaternion.identity);
                break;
            case -1:    //test world
                ballGO = Instantiate(ball);
                break;
        }

        FollowBall.CalculateOffset(ballGO.transform.position);


        //ballGO = Instantiate(ball);

        //clubGO = Instantiate(driver, ballGO.transform);

        //reset club to a driver
        currClub = ClubState.driver;

        //reset the goal
        Hole.goalMet = false;

        //reset the shot count
        shotCount = 0;

        //wait for the user to hit the ball
        state = BallState.waiting;

        //Set Power bar to inactive
        outerPanelGO.SetActive(false);
        innerPanelGO.SetActive(false);
    }

    public void EndLevel()
    {
        level++;

        //load the next level
        print(level);
        switch (level)
        {

            case 1:
                SceneManager.LoadScene("FirstLevel_Normal");
                break;
            case 2:
                SceneManager.LoadScene("SecondLevel_Normal");
                break;
            case 3:
                SceneManager.LoadScene("ThirdLevel_Normal");
                break;
            case 4:
                SceneManager.LoadScene("FirstLevel_House");
                break;
            case 5:
                SceneManager.LoadScene("SecondLevel_House");
                break;
            case 6:
                SceneManager.LoadScene("ThirdLevel_House");
                break;
            case 7:
                SceneManager.LoadScene("FirstLevel_Space");
                break;
            case 8:
                SceneManager.LoadScene("SecondLevel_Space");
                break;
            case 9:
                SceneManager.LoadScene("ThirdLevel_Space");
                break;
            case -1:    //test world
                SceneManager.LoadScene("level1");
                break;
            default:    //end the game
                SceneManager.LoadScene("PlaceholderEndScreen");
                break;
        }
    }

    public void BallFellInWater()
    {
        print("You fell in the water!");
        alertText.text = "You Fell in the Water! Resetting...";
        isTeleporting = true;
        Invoke("ResetBallPosition", 3f);
        Invoke("ResetAlert", 3f);
        inWater = false;
    }

    public void BallFellOutOfBounds()
    {
        print("You went out of bounds!");
        alertText.text = "You Fell out of bounds! Resetting...";
        isTeleporting = true;
        Invoke("ResetBallPosition", 3f);
        Invoke("ResetAlert", 3f);
        outOfBounds = false;
    }

    public void ResetAlert()
    {
        alertText.text = "";
    }

    public void ResetBallPosition()
    {
        Ball.S.rb.transform.SetPositionAndRotation(previousShot, Quaternion.identity);
        Ball.S.rb.Sleep();
        isTeleporting = false;
    }
}

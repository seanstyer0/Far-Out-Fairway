using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    List<int> scores;

    public GameObject scoreboardGO;

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


    // Start is called before the first frame update
    void Start()
    {
        this.scores = RunGame.scores;

        int total = 0;

        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] != null)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour
{
    
    public MissCheck missCheck;
    public Score score;
    public Combo combo;

    public Text rank;
    public Text title;
    public Text finalScore;
    public Text maxCombo;
    public Text miss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rank();
    }

    public void Rank()
    {
        float rankTotal = (missCheck.missCount*100)/(score.blueStick.total + missCheck.missCount);

        if (rankTotal == 0)
        {
            rank.text = "Rank SSS";
            title.text = "!! Full Combo !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = "+ missCheck.missCount.ToString();

        }
        else if (rankTotal < 3)
        {
            rank.text = "Rank SS";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 5)
        {
            rank.text = "Rank S";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 8)
        {
            rank.text = "Rank A+";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 10)
        {
            rank.text = "Rank A";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 12)
        {
            rank.text = "Rank B+";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 15)
        {
            rank.text = "Rank B";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else if (rankTotal < 18)
        {
            rank.text = "Rank C+";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        else
        {
             rank.text = "Rank C";
            title.text = "!! Mission Complete !!";
            finalScore.text = "Score = " + score.blueStick.total.ToString();
            maxCombo.text = "Max Combo = " + combo.maxCombo.ToString();
            miss.text = "Miss = " + missCheck.missCount.ToString();
        }
        Debug.Log(rankTotal);
    }
}

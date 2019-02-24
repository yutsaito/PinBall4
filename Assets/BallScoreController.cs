using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScoreController : MonoBehaviour
{
    //SmallStarPoint
    //private int pointss = 10;
    //LargeStarPoint
    //private int pointls = 20;
    //SmallCloudPoint
    //private int pointsc = 5;
    //LargeCloudPoint
    //private int pointlc = 15;
    //ｽｺｱ初期値
    private int score = 0;
    //ｹﾞｰﾑｽｺｱ表示用ﾃｷｽﾄのｵﾌﾞｼﾞｪｸﾄの取得のための箱
    private GameObject gamescoreText;

    // Use this for initialization
    void Start()
    {
        //ｼｰﾝ中のGameScoreTextｵﾌﾞｼﾞｪｸﾄを取得
        this.gamescoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {

    }       //scoreを計算(Tagで当たりを判定)
            //onColloision
            //cube同士での衝突＋100 cube以外との衝突＋100
    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "SmallStarTag")
        {
            score += 10;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 20;
        }
        else if (yourTag == "SmallCloudTag")
        {
            score += 5;

        }
        else if (yourTag == "LargeCloudTag")
        {
            score = +15;
        }

        //scoreをﾃｷｽﾄにして表示
        //this.gamescoreText.GetComponent<Text>().text = score.ToString("D4") + " Pts";
        this.gamescoreText.GetComponent<Text>().text = score + " pts";
    }
}

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

    ////流れ星ｲﾝｽﾀﾝｽ ここで"public"宣言しておけば、後からInspectorで、これにProjectの「ShootingStarPrefab」をﾄﾞﾗｯｸﾞして指定できる
    public GameObject shootingStarPrefab;
    private bool is500ptss;
    Rigidbody myRigidbody;
    private float scoreDevide100 = 0.00f;
    private float scoreDevide100Before = 0.00f;

    // Use this for initialization
    void Start()
    {
        //ｼｰﾝ中のGameScoreTextｵﾌﾞｼﾞｪｸﾄを取得
        this.gamescoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        ////100点の倍数にちょうどなったら流れ星を発生させる
        ////これだとすごくたくさんできてしまう  `→　scoreDevide100 と ScoreDevide100Beforeを比べて、大きくなっていれば次のscore%100の条件に進めるようにした
        scoreDevide100 = score / 100;
        if (scoreDevide100 > scoreDevide100Before && score % 100 == 0)
        {
            ShootingStarGeneration();
            Debug.Log("There is a shootingstar!");
        }
    }

    void ShootingStarGeneration()
        {
        GameObject shootingStar = Instantiate(shootingStarPrefab) as GameObject;
        myRigidbody = shootingStar.GetComponent<Rigidbody>();
        myRigidbody.AddForce(-3, 1, 1);     //左上に打ち出す
        scoreDevide100Before = scoreDevide100;
        //   //shootingStar.transform.position = new Vector3(0, shootingStar.transform.position.y, 0);
        }



        //scoreを計算(Tagで当たりを判定)
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
                score += 15;
            }
            else if (yourTag == "ShootingStarTag")
            {
                score +=555;
            }

            //scoreをﾃｷｽﾄにして表示
            //this.gamescoreText.GetComponent<Text>().text = score.ToString("D4") + " Pts";
            this.gamescoreText.GetComponent<Text>().text = score + " pts";
        }
}

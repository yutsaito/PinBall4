using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//うまく光らないので、改造したところをもとに戻す   →　Directonal Lightの設定が悪いみたい

public class BrightnessRegulator : MonoBehaviour
{
    //Materialを入れる 箱を用意
    Material myMaterial;
    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission=2.0f;
    //private float magEmission = 10.0f;
    //角度
    private int degree=0;
    //発光速度
    //private float speed = 1.0f;
    //private int speed = 10; 
    //private int speed = 20; //Update関数内で、瞬時に光ゆっくり消えるようにしたため、速度を速めた
    private int speed = 5;
    //ターゲットのデフォルト色
    //string defaultColor;
    Color defaultColor = Color.white;

    //Score
    private int score=0;        //total score
    private int pointForEach;       //各ｵﾌﾞｼﾞｪｸﾄのｽｺｱ
    //ｽｺｱ表示するﾃｷｽﾄ（ｹﾞｰﾑｵﾌﾞｼﾞｪｸﾄ)
    GameObject scoreText;

    //ボール
    GameObject ball; 




    // Start is called before the first frame update
    void Start()
    {
        //Tagにごとに光らせる色を設定するため場合分け（このｽｸﾘﾌﾟﾄは全ての星・雲につけるので）
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            this.pointForEach = 10;
        }
        else if(tag=="LargeStarTag"){
            this.defaultColor = Color.yellow;
            this.pointForEach = 20;

        }
        else if (tag == "SmallCloudTag" || tag=="LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
            this.pointForEach = 30;
        }
        //ｵﾌﾞｼﾞｪｸﾄにｱﾀｯﾁしているMaterialを取得
        //myMaterial = this.GetComponent<Material>();  //ﾌﾟﾛｸﾞﾗﾑ的には通ったが実行時にエラーがでて間違えてた！ComponentはRenderer！そのFunction(?)materialをgetする
        this.myMaterial = GetComponent<Renderer>().material;
        //ｵﾌﾞｼﾞｪｸﾄの最初の色を設定
        //myMaterial.color = this.defaultColor*minEmission;  このcodeでも通る！だめなのか？ →多分参照のみ、代入はできないのだろう
        //myMaterial.Emission.color = this.defaultColor * minEmission; これは通らず
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
        //ボールを見つけておく
        ball =GameObject.Find("Ball");

                         //ScoreTextを探しておく
                          // this.scoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()       //光の強さを弱→強→弱と滑らかに変化するように計算
    {
        if (this.degree >= 0)
        {
            //光らせる強度を計算する
            // float emissionStrength=minEmission+magEmission*Mathf.Sin(Time.time*) できなかった・・・
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            //Eissionに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);
            //現在の角度を小さくする
            this.degree -= this.speed;  //角度を180度に設定、衝突してSin180°にし、Updateで10°削っていくので、徐々に光って徐々に消える感じ
            //瞬時に光り、消えるのは若干残像を伴うようにする
            if (this.degree > 90)
            {
                this.degree -= this.speed*2;
            }

        }
    }
    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision collision)
    {
        //角度を180度に設定、衝突してSin180°にし、Updateで10°削っていくので、徐々に光って徐々に消える感じ
        this.degree = 180;
                          //ScoreのUpDate
                         //  this.score += pointForEach;
        //this.scoreText.GetComponent<Text>().text = score + " pts";

        //星の上部に当たったら力を加えたい
        if (tag == "LargeStarTag")
        {

            if (ball.transform.position.y > this.transform.position.y+0.3f)
            {
                Rigidbody myRigidbody = ball.GetComponent<Rigidbody>();
                Vector3 forceDirection = new Vector3(myRigidbody.velocity.x*(-0.5f)*30.0f, myRigidbody.velocity.y*(-0.5f)*30.0f, myRigidbody.velocity.z*(-0.5f)*30.0f);  //跳ね返る方向ﾍﾞｸﾄﾙは直前の速度ﾍﾞｸﾄﾙの
                myRigidbody.AddForce(forceDirection);
               // Debug.Log(myRigidbody.velocity.y);
                //そこそこうまくできたが、壁を簡単に乗り越えるようになった。壁やｵﾌﾞｼﾞｪｸﾄのY方向の厚みを2倍にし、カメラをとうざけ角度を狭めた
            }
        }


    
    }
}

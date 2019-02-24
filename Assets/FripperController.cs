using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint ｺﾝﾎﾟｰﾈﾝﾄを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointｺﾝﾎﾟｰﾈﾝﾄ取得
        // myHingeJoint=GameObject.Find()    →　このScriptはFripperにｱﾀｯﾁするので、そのFripperについてはFindする必要はない
        myHingeJoint = this.GetComponent<HingeJoint>();      //thisいらない?  →　Thisつけても大丈夫みたい

        //ﾌﾘｯﾊﾟｰの傾きを設定
        //myHingeJoint.
       // JointSpring jointSpr = myHingeJoint.spring;　　本来、こう書いてからﾒｿｯﾄﾞにするのが順序だと思う
        SetAngle(this.defaultAngle);        //SetAngleは下に記述
    }

    // Update is called once per frame
    void Update()
    {
        //←矢印キーを押した時左フリッパーを動かす
       // if(Input.GetKeyDown(KeyCode==LeftArrow)&& tag == "LeftFripper")
       if(Input.GetKeyDown(KeyCode.LeftArrow) && tag=="LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //→矢印キーを押した時右フリッパーを動かす 
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //矢印キー離された時フリッパーをもとに戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }
    public void SetAngle(float angle)
    {   //JoinSpring はすっかり忘れていた・・・が、どこにある？
        JointSpring jointSpr = myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;

       // Spring jointSpr = myHingeJoint.spring;　なんでいけないんだろう？

        
        
    }
}

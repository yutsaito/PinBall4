using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // private float rotSpeed = 1;  //全ての星が同じ速度で回転する
    public float rotSpeed;      //各星ごとに設定する
    // Start is called before the first frame update
    void Start()
    {
        //回転開始角度
        this.transform.Rotate(0, Random.Range(0, 360), 0);      //this を使うということは、これを星にｱﾀｯﾁすることを考えている
    }

    // Update is called once per frame
    void Update()
    {
        // this.transform.Rotate(0, transform.rotation.y + Mathf.Sin(this.rotSpeed), 0);
        this.transform.Rotate(0, this.rotSpeed, 0);  //Yの回転は、transform.rotation.y+rotSpeedじゃない。この書き方だけで、相対角度になるらしい。
                                                //絶対角度の書き方を調べること！

    }
}

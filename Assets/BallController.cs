using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるZ軸の最大値
    private float visiblePosZ = -6.5f;
    //ｹﾞｰﾑｵｰﾊﾞｰを表示するﾃｷｽﾄ
    //string gameOverText;
    private GameObject gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のｹﾞｰﾑｵﾌﾞｼﾞｪｸﾄを取得
        //gameObjectText = GameObject.Find("GameOverText");
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合にｹﾞｰﾑｵｰﾊﾞｰを表示
        if (transform.position.z < visiblePosZ)
        {
            //Text gameOverText = gameoverText.GetComponent<Text>().text;   
            Text gameOverText=gameoverText.GetComponent<Text>();        //Textクラスの「text」は、Textコンポーネントに表示する文字列を指定できます。
            gameOverText.text = "Game Over";
            //ここでは、シーン中から取得したGameOverTextにアタッチされているTextコンポーネントのtextに、「Game Over」という文字列を代入しています。
            //this.gameoverText.GetComponent<Text>().text="Game Over";
        }


    }
}

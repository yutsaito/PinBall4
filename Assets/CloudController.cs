using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //最小サイズ
    private float minimum = 1.0f;
    //拡大縮小ｽﾋﾟｰﾄﾞ
   // private float magSpeed = 10.0f;  //雲の拡大縮小が同期してしまうので、改良する
    public float magSpeed = 10.0f;
    //拡大率
    //private float magnification = 0.07f;
    public float magnification = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //thisを使うので、これはこのｽｸﾘﾌﾟﾄをCloudにｱﾀｯﾁすることが前提、そのｱﾀｯﾁされたｹﾞｰﾑｵﾌﾞｼﾞｪｸﾄのことを「this」といっている
        //雲を拡大縮小 →　Time.timeがすらっとでてこなかった。方向を把握していなかった、機械的にx,yだと思ってしまった
        //this.transform.localScale = new Vector3(this.minimum+Mathf.Sin(Time.time*magSpeed)*this.magnification, this.minimum + Mathf.Sin(Time.time * magSpeed) * this.magnification, 1);
        this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarController : MonoBehaviour
{
    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {  //左に移動する
        myRigidbody.AddForce(-5, 0, 0);

        //Y座標が小さくなるに従い小さくなり、途中でDestroyする
        if (this.transform.position.y < -0.8f) { Destroy(gameObject); }
        Debug.Log(this.transform.position.y);

    }
}

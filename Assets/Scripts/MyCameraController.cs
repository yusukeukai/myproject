using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {
    //Unityちゃんのオブジェクト
    private GameObject texiranosaurusu;
    //Unityちゃんとカメラの距離
    private float difference;

	// Use this for initialization
	void Start () {
        //Unityちゃんのオブジェクトを取得
        this.texiranosaurusu = GameObject.Find("texiranosaurusu");
        //Unityちゃんとカメラの位置（y座標）の差を求める
        //this.difference = unitychan.transform.position.x - this.transform.position.x;
		
	}
	
	// Update is called once per frame
	void Update () {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.texiranosaurusu.transform.position.z -2);
       
    }
}

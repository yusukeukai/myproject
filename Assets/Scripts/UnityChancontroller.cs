﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//（追加）

public class UnityChancontroller : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    //private Animator myAnimator;

    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    private Rigidbody myRigidbody;

    //前進するための力（追加）
    private float forwardForce = 17.0f;

    //左右に移動するための力（追加）
    private float turnForce = 500.0f;

    //ジャンプするための力（追加）
    private float upForce = 400.0f;

    //左右の移動できる範囲（追加）
    private float movableRange = 3.4f;

    //動きを減速させる係数（追加）
    private float coefficient = 0.95f;

    //ゲーム終了の判定（追加）
    private bool isEnd = false;

    //ゲーム終了時に表示するテキスト（追加）
    private GameObject stateText;

    //スコアを表示するテキスト（追加）
    private GameObject scoreText;

    //得点（追加）
    private int score = 0;

    //左ボタン押下の判定（追加）
    private bool isLButtonDown = false;

    //右ボタン押下の判定（追加）
    private bool isRButtonDown = false;




    // Use this for initialization
    void Start()
    {

        //Animatorコンポーネントを取得
        //this.myAnimator = GetComponent<Animator>();

        //走るアニメーション開始
        //this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

        //シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {

        //ゲーム終了ならUnityちゃんの動きを減衰する（追加）
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            //this.myAnimator.speed *= this.coefficient;
        }

        //Unityちゃんに前方向に力を加える（追加）
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {

            //左に移動（追加）
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {

            //右に移動（追加）
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }
        //Jumpステートの場合はJumpにfalseをセットする（追加）
        //if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            //this.myAnimator.SetBool("Jump", false);

        }

        //ジャンプしていない時にスペースが押されたらジャンプする（追加）
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {

            //ジャンプアニメを再生（追加）
            //this.myAnimator.SetBool("Jump", true);

            //Unityちゃんに上方向の力を加える（追加）
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnTriggerEnter(Collider other)
    {

        //障害物に衝突した場合（追加）
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            //stateTextにGAMEOVERを表示（追加）
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合（追加）
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //stateTextにGAMECLEARを表示（追加）
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }

        //コインに衝突した場合（追加）
        if (other.gameObject.tag == "CoinTag")
        {
            //スコアを加算（追加）
            this.score += 10;

            //ScoreText獲得した点数を表示（追加）
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";

            //パーティクルを再生（追加）
            //GetComponent<ParticleSystem>().Play();

            //接触したコインのオブジェクトを破棄（追加）
            Destroy(other.gameObject);
        }


    }
    //ジャンプボタンを押した場合の処理（追加）
    public void GetMyJumpButtonDown()
    {
        if (this.transform.position.y < 0.5f)
        {
            //this.myAnimator.SetBool("jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
}




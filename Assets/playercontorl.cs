using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontorl : MonoBehaviour
{
    //刚体
    private Rigidbody rBody;
    //判断是否在地面
    private bool isGround;
    //音频组件
    private AudioSource footPlayer;
    // Start is called before the first frame update
    void Start()//执行一次
    {   //获取刚体组件
        rBody = GetComponent<Rigidbody>(); 
        //获取脚步声音组件
        //footPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()//每帧执行
    {
        //按下空格键
        if(Input.GetKeyDown(KeyCode.Space)&& isGround==true) {
            //跳跃:给刚体一个向上的力
            rBody.AddForce(Vector3.up * 200);
        }
        //是否按下移动键
        float horizontal = Input.GetAxis("Horizontal");//水平
        float vertical = Input.GetAxis("Vertical");//垂直
        if((horizontal != 0||vertical !=0)&&isGround==true)
        {
            //移动且在地面上,播放，当前没有脚步声
            if(footPlayer.isPlaying == false)
            { //播放
                footPlayer.Play();
            }

        }
        else
        {
            //没有移动，停止
            footPlayer.Stop();
             
        }
    }
    //产生碰撞
    private void OnCollisionEnter(Collision collision)
    {
        //判断是不是地面
        if(collision.collider.tag == "Ground")
        {

            //踩在地面上
            isGround = true;
        } 
    }
    //结束碰撞
    private void OnCollisionExit(Collision collision)
    {
        //判断是不是地面
        if (collision.collider.tag == "Ground")
        {
            //离开地面上
            isGround= false;

        }
    }

}

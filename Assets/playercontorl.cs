using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontorl : MonoBehaviour
{
    //����
    private Rigidbody rBody;
    //�ж��Ƿ��ڵ���
    private bool isGround;
    //��Ƶ���
    private AudioSource footPlayer;
    // Start is called before the first frame update
    void Start()//ִ��һ��
    {   //��ȡ�������
        rBody = GetComponent<Rigidbody>(); 
        //��ȡ�Ų��������
        //footPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()//ÿִ֡��
    {
        //���¿ո��
        if(Input.GetKeyDown(KeyCode.Space)&& isGround==true) {
            //��Ծ:������һ�����ϵ���
            rBody.AddForce(Vector3.up * 200);
        }
        //�Ƿ����ƶ���
        float horizontal = Input.GetAxis("Horizontal");//ˮƽ
        float vertical = Input.GetAxis("Vertical");//��ֱ
        if((horizontal != 0||vertical !=0)&&isGround==true)
        {
            //�ƶ����ڵ�����,���ţ���ǰû�нŲ���
            if(footPlayer.isPlaying == false)
            { //����
                footPlayer.Play();
            }

        }
        else
        {
            //û���ƶ���ֹͣ
            footPlayer.Stop();
             
        }
    }
    //������ײ
    private void OnCollisionEnter(Collision collision)
    {
        //�ж��ǲ��ǵ���
        if(collision.collider.tag == "Ground")
        {

            //���ڵ�����
            isGround = true;
        } 
    }
    //������ײ
    private void OnCollisionExit(Collision collision)
    {
        //�ж��ǲ��ǵ���
        if (collision.collider.tag == "Ground")
        {
            //�뿪������
            isGround= false;

        }
    }

}

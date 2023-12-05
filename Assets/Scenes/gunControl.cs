using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunControl : MonoBehaviour
{
    //���������
    public Transform firePoint;
    //������Ԥ���
    public GameObject firePre;
    //�����ӵ���
    public Transform bulletPoint;
    //�����ӵ�Ԥ���
    public GameObject bulletPre;
    //����ǹ����Ч
    public AudioClip clip;
    //�������ӵ�
    public AudioClip ckeck;
    //�����ӵ�ui
    public Text bulletText;
    //�ӵ�����
    private int bulletCount = 10;
    //������
    private float cd = 0.2f;
    //��ʱ��
    private float timer = 0;
    //�����������
    private AudioSource gunPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        gunPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   //����
        
        //��ʱ
        timer += Time.deltaTime;
        //�����ʱ������cd�����������������ӵ�������
        if (timer > cd && Input.GetMouseButton(0) && bulletCount > 0)
        {
            //���ü�ʱ��
            timer = 0;
            //���ɻ���
            Instantiate(firePre, firePoint.position, firePoint.rotation);
            //�����ӵ�
            Instantiate(bulletPre, bulletPoint.position, bulletPoint.rotation);
            //�ӵ���������
            bulletCount--;
            //ˢ��Ui
            bulletText.text = bulletCount + "";
            //����ǹ��
            gunPlayer.PlayOneShot(clip);
            //�ӵ����꣬�Զ����ӵ�
           
        }
        if (bulletCount == 0)
        {
            //���Ż��ӵ�����
            GetComponent<Animator>().SetTrigger("Reload");
            //������Ч
            //gunPlayer.PlayOneShot(ckeck);
            //1.5��󻻺��ӵ�ssss
            Invoke("Reload", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 0;
            //���Ż��ӵ�����
            GetComponent<Animator>().SetTrigger("Reload");
            //������Ч
            //gunPlayer.PlayOneShot(ckeck);
            //1.5��󻻺��ӵ�sssss
            Invoke("Reload", 1.5f);


        }



    }

    private void Reload()
    {
        bulletCount = 10;
        //ˢ��Ui
        bulletText.text = bulletCount + "";
    }
}


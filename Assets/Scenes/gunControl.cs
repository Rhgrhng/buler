using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunControl : MonoBehaviour
{
    //关联火焰点
    public Transform firePoint;
    //关联火预设点
    public GameObject firePre;
    //关联子弹点
    public Transform bulletPoint;
    //关联子弹预设点
    public GameObject bulletPre;
    //关联枪声音效
    public AudioClip clip;
    //关联换子弹
    public AudioClip ckeck;
    //关联子弹ui
    public Text bulletText;
    //子弹个数
    private int bulletCount = 10;
    //开火间隔
    private float cd = 0.2f;
    //计时器
    private float timer = 0;
    //声音播放组件
    private AudioSource gunPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        gunPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   //换弹
        
        //计时
        timer += Time.deltaTime;
        //如果计时器满足cd，按下鼠标左键，有子弹，开火
        if (timer > cd && Input.GetMouseButton(0) && bulletCount > 0)
        {
            //重置计时器
            timer = 0;
            //生成火焰
            Instantiate(firePre, firePoint.position, firePoint.rotation);
            //生成子弹
            Instantiate(bulletPre, bulletPoint.position, bulletPoint.rotation);
            //子弹个数减少
            bulletCount--;
            //刷新Ui
            bulletText.text = bulletCount + "";
            //播放枪声
            gunPlayer.PlayOneShot(clip);
            //子弹打完，自动换子弹
           
        }
        if (bulletCount == 0)
        {
            //播放换子弹动画
            GetComponent<Animator>().SetTrigger("Reload");
            //播放音效
            //gunPlayer.PlayOneShot(ckeck);
            //1.5秒后换好子弹ssss
            Invoke("Reload", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 0;
            //播放换子弹动画
            GetComponent<Animator>().SetTrigger("Reload");
            //播放音效
            //gunPlayer.PlayOneShot(ckeck);
            //1.5秒后换好子弹sssss
            Invoke("Reload", 1.5f);


        }



    }

    private void Reload()
    {
        bulletCount = 10;
        //刷新Ui
        bulletText.text = bulletCount + "";
    }
}


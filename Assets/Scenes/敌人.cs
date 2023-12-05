using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敌人 : MonoBehaviour
{
    private int hp = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {   //判断是否碰到了子弹
        if (other.tag == "Bullet")
        {
            //减血
            hp--;
            //hp=0死
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

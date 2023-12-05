using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //给子弹一个速度
        GetComponent<Rigidbody>().AddForce(transform.forward * 900);
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        //碰到物体就消失
        Destroy(gameObject);
    }



}

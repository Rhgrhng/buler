using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���ӵ�һ���ٶ�
        GetComponent<Rigidbody>().AddForce(transform.forward * 900);
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        //�����������ʧ
        Destroy(gameObject);
    }



}

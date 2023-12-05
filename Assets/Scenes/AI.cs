using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//״̬
public enum EnemyState
{     
    idle,
    run,

    attack

}


public class AI : MonoBehaviour
{
    //״̬
    public EnemyState CurrentState =EnemyState.idle;
    //����������
    private Animation ani;
    //���
    private Transform player;
    //����
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
        ani =GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called on
    // ce per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //�ж�״̬
        switch (CurrentState)
        {
            case EnemyState.idle:
                //վ��״̬���ж����һ�����ף�Ϊ�ܲ�
                
                if (distance >1 && distance <= 5)
                {
                    CurrentState = EnemyState.run;
                }
                //����ֹͣs
                agent.isStopped = true;
                break;
            case EnemyState.run:
                //>3�ױ�Ϊվ��
                if (distance > 5)
                {
                    CurrentState=EnemyState.idle;
                }
              
                //�ܲ�����
                ani.Play("run");
                //������ʼ
                agent.isStopped=false;
                agent.SetDestination(player.position);
                break;
            case EnemyState.attack:
                break;
        }




    }
}

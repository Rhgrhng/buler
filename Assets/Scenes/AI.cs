using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//状态
public enum EnemyState
{     
    idle,
    run,

    attack

}


public class AI : MonoBehaviour
{
    //状态
    public EnemyState CurrentState =EnemyState.idle;
    //动画控制器
    private Animation ani;
    //玩家
    private Transform player;
    //导航
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
        //判断状态
        switch (CurrentState)
        {
            case EnemyState.idle:
                //站立状态，判断玩家一到三米，为跑步
                
                if (distance >1 && distance <= 5)
                {
                    CurrentState = EnemyState.run;
                }
                //导航停止s
                agent.isStopped = true;
                break;
            case EnemyState.run:
                //>3米变为站立
                if (distance > 5)
                {
                    CurrentState=EnemyState.idle;
                }
              
                //跑步动画
                ani.Play("run");
                //导航开始
                agent.isStopped=false;
                agent.SetDestination(player.position);
                break;
            case EnemyState.attack:
                break;
        }




    }
}

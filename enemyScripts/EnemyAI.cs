using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum ZombieState
{
    Idle = 0,
    Walk = 1,
    Dead = 2,
    Attack =3,
}
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    ZombieState zombieState;
    GameObject playerObject;
    PlayerHP playerHP;
    Enemyhp enemyhp;
    // Start is called before the first frame update
     void Start()
    {
        enemyhp = GetComponent<Enemyhp>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHP = playerObject.GetComponent<PlayerHP>();
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyhp.GetHP() <= 0)
        {
            SetState(ZombieState.Dead);
        }

        switch (zombieState)
        {
            case ZombieState.Dead:
                KillZombie();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Walk:
                SearchForTarger();
                break;
            case ZombieState.Idle:
                SearchForTarger();
                break;
            
           
            default:
                break;
        }
    }

    private void Attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped = true;

    }
    void MakeAttack()
    {
        Debug.Log("makeattack çalıştı");
        playerHP.DeductHp(33);
        SearchForTarger();
    }

    private void SearchForTarger()
    {
        float Distance = Vector3.Distance(transform.position, playerObject.transform.position);
        if(Distance < 1.5f)
        {
            Attack();
        }
        else if (Distance < 10)
        {
            MoveToPlayer();
        }
        else
        {
            SetState(ZombieState.Idle);
            agent.isStopped = true;
        }
    }

    private void SetState(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("state", (int)state);
        
    }

    private void MoveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        SetState(ZombieState.Walk);

    }

    private void KillZombie()
    {
        SetState(ZombieState.Dead);
        agent.isStopped = true;
        Destroy(gameObject, 5);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
enum enemystate
{
    idle,
    patrol,
    chase,
    attack
}

public class enemy_logic : MonoBehaviour
{
    [SerializeField] enemystate m_currentstate = enemystate.idle;
    public Transform startposition;
    public float enemyheath = 30f;
    float enemymaxhealth = 30f;
    public Image enemyhb;
    public Transform endposition;
    Vector3 currentposition;
    NavMeshAgent m_navmeshagent;
    float MAX_cooldown = 0.5f;
    float enemy_cooldown = 0.5f;
    public Transform player;
    int damage = 10;
    private float chasingdistance = 5.0f;
    float meelleradius = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        currentposition = startposition.position;
        m_navmeshagent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
       
        switch (m_currentstate)
        {
            case (enemystate.idle):
                searchforplayer();
                break;

            case (enemystate.patrol):
                searchforplayer();
                if (startposition && endposition)
                {
                    patrol();
                }
                break;
            case (enemystate.chase):
                chase();
                break;
            case (enemystate.attack):
                updateattack();
                break;

        }

        
    }
    void updateattack()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance<meelleradius)
        {
            enemy_cooldown -= Time.deltaTime;
            if (enemy_cooldown < 0)
            {
                enemy_cooldown = MAX_cooldown;
                player.GetComponent<characterScript>().takedamage(damage);
            }
        }
        else
        {
            m_currentstate = enemystate.chase;
        }
    }
    void searchforplayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < chasingdistance)
        {
            m_currentstate = enemystate.chase;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.5f, 0.5f, 1, 0.45f);
        Gizmos.DrawSphere(transform.position, chasingdistance);
    }
    void chase()
    {
        if (player && m_navmeshagent)
        {
            m_navmeshagent.SetDestination(player.position);
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < m_navmeshagent.stoppingDistance)
        {
            m_navmeshagent.isStopped = true;
            m_navmeshagent.velocity = Vector3.zero;
        }
        else if(distance<meelleradius)
        {
            m_currentstate = enemystate.attack;
        }
        else
        {
            m_navmeshagent.isStopped = false;
        }
    }
    void patrol()
    {
        if (currentposition != Vector3.zero && m_navmeshagent)
        {
            m_navmeshagent.SetDestination(currentposition);
        }
        float distance = Vector3.Distance(transform.position, currentposition);
        if (distance < m_navmeshagent.stoppingDistance)
        {
           if(currentposition==startposition.position)
            {
                currentposition = endposition.position;
            }
           else
            {
                currentposition = startposition.position;
            }
        }
    }
    public void takedamage(int damage)
    {
        m_currentstate = enemystate.chase;
        enemyheath -= damage;
        currentenemyhealth();
    }

    private void currentenemyhealth()
    {
        if(enemyheath<=0)
        {
            //enemy die
            Destroy(gameObject);
        }

        enemyhb.fillAmount = enemyheath / enemymaxhealth;
    }
}

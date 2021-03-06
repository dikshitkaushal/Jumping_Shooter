﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_logic : MonoBehaviour
{
    Rigidbody m_rigidbody;
    float velocity = 20.0f;
    float bulletlifetime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        m_rigidbody = GetComponent<Rigidbody>();
        if(m_rigidbody)
        {
            m_rigidbody.velocity = velocity * transform.up;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("target") )
        {
            //destroy other.gameobject
            Destroy(other.gameObject);

            //destroy bullet
            Destroy(gameObject);
        }
        else if(other.CompareTag("enemy"))
        {
            enemy_logic enemyhealth = other.gameObject.GetComponent<enemy_logic>();
            if(enemyhealth)
            {
                enemyhealth.takedamage(10);
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        bulletlifetime -= Time.deltaTime;
        if (bulletlifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}

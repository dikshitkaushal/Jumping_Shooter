﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_logic : MonoBehaviour
{
    Rigidbody m_rigidbody;
    float velocity = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        if(m_rigidbody)
        {
            m_rigidbody.velocity = velocity * transform.up;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

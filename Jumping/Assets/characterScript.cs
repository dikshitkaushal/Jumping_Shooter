using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    CharacterController m_charactercontroller;
    float m_horizontalaxis;
    float m_speed = 5f;
    float jumpd = 1f;
    float gravity = 0.05f;
    bool isjumping = false;
    float m_verticalaxis;
    Vector3 total_move;
    Vector3 m_movement;
    // Start is called before the first frame update
    void Start()
    {
        m_charactercontroller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalaxis = Input.GetAxis("Horizontal");
        m_verticalaxis = Input.GetAxis("Vertical");
        Debug.Log(m_horizontalaxis);
        if(Input.GetButtonDown("Jump") && !isjumping)
        {
            isjumping = true;
        }
    }
    private void FixedUpdate()
    {
        m_movement.x = m_horizontalaxis * m_speed * Time.deltaTime;
        m_movement.z = m_verticalaxis * m_speed * Time.deltaTime;
        if (m_charactercontroller)
        {
            m_charactercontroller.Move(m_movement);
        }
        //controlling Gravity
        if(!m_charactercontroller.isGrounded)
        {
            if (m_movement.y > 0)
            {
                m_movement.y -= gravity;
            }
            else
            {
                m_movement.y -= gravity * 3f;
            }
        }
        else
        {
            m_movement.y = 0;
        }
        //setting jumpheight to y
        if(isjumping)
        {
            m_movement.y = jumpd;
            isjumping = false;
        }
    }
}
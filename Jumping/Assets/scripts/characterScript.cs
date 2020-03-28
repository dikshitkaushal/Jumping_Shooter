using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    
    CharacterController m_charactercontroller;
    float m_horizontalaxis;
    float m_speed = 5f;
    public float jumpd = 50f;
    float gravity = 0.05f;
    public bool isjumping = false;
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
        total_move = new Vector3(-m_verticalaxis, 0, m_horizontalaxis);
        Debug.Log(m_horizontalaxis);
        if(Input.GetButtonDown("Jump") && !isjumping)
        {
            isjumping = true;

        }
        

    }
    public void Rotate_With_Mouse()
    {
        Vector3 mouse_screen_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse_screen_pos - player_pos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
    private void FixedUpdate()
    {

        /* m_movement = total_move * m_speed * Time.deltaTime;*/

        m_movement.z = m_horizontalaxis * m_speed * Time.deltaTime;
        m_movement.x = -m_verticalaxis * m_speed * Time.deltaTime;
        /* if (total_move != Vector3.zero)
         {
             transform.forward = total_move.normalized;
         }*/
        Rotate_With_Mouse();
        if (m_charactercontroller)
        {
            m_charactercontroller.Move(m_movement);
        }
        
        //controlling Gravity
        if (!m_charactercontroller.isGrounded)
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
        if (isjumping)
        {
            m_movement.y = jumpd;
            isjumping = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_logic : MonoBehaviour
{
    [SerializeField] GameObject m_bulletprefab;
    [SerializeField] Transform m_bullet_spawnPoint;
    const float MAX_cooldown = 0.5f;
    float current_cooldown = 0;
    float bullet_count = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(current_cooldown>0)
        {
            current_cooldown -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1") && current_cooldown<=0 && bullet_count>0)
        {
            if(m_bulletprefab && m_bullet_spawnPoint)
            {
                Instantiate(m_bulletprefab, m_bullet_spawnPoint.position, m_bullet_spawnPoint.rotation * m_bulletprefab.transform.rotation);
                current_cooldown = MAX_cooldown;
                --bullet_count;
             
            }
            
        }
    }
}

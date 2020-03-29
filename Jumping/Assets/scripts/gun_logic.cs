using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gun_logic : MonoBehaviour
{
    [SerializeField] GameObject m_bulletprefab;
    [SerializeField] Transform m_bullet_spawnPoint;
    [SerializeField] Text bullet_ammo;
    [SerializeField] AudioClip[] clips;
    AudioSource source;
    const float MAX_cooldown = 0.5f;
    float current_cooldown = 0;
    float bullet_count = 3f;
    public bool isequpped = false;
    Rigidbody m_rigidbody;
    Collider m_collider;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_collider = GetComponent<Collider>();
        source = GetComponent<AudioSource>();
        setAmmo();
    }
    void playsound(int clip)
    {
        source.clip = clips[clip];
        source.Play();
           
    }
    public void setAmmo()
    {
        bullet_ammo.text = "Ammo : " + bullet_count;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isequpped)
        {
            return;
        }
        
        if (current_cooldown>0)
        {
            current_cooldown -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && current_cooldown <= 0)
        {
            if (bullet_count > 0)
            {
                --bullet_count;
                setAmmo();
                if (m_bulletprefab && m_bullet_spawnPoint)
                {
                    Instantiate(m_bulletprefab, m_bullet_spawnPoint.position, m_bullet_spawnPoint.rotation * m_bulletprefab.transform.rotation);
                    current_cooldown = MAX_cooldown;
                    playsound(0);
                }
            }
            else
            {
                playsound(1);
            }
            
        }
    }
    public void refill_ammo()
    {
        bullet_count += 3f;
        setAmmo();
        playsound(2);
    }
    public void equip_weapon()
    {
        isequpped = true;
        if(m_rigidbody)
        {
            m_rigidbody.useGravity = false;
        }
        if(m_collider)
        {
            m_collider.enabled = false;
        }
    }
    public void unequip_weapon()
    {
        isequpped = false;
        if (m_rigidbody)
        {
            m_rigidbody.useGravity = true;
        }
        if (m_collider)
        {
            m_collider.enabled = true;
        }
    }
}

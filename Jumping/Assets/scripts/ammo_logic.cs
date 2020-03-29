using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_logic : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gun_logic gun= other.GetComponentInChildren<gun_logic>();
            if(gun)
            {
                gun.refill_ammo();
                Destroy(gameObject);
            }
        }
    }
}

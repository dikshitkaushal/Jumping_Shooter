using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodyscr : MonoBehaviour
{
    Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(new Vector3(0, 100f, 0));
        }
    }
}

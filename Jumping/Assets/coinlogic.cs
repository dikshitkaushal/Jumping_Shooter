using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinlogic : MonoBehaviour
{
    float speed = 2f;
    Quaternion pos;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left, 1f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

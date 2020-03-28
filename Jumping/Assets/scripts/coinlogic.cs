using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinlogic : MonoBehaviour
{
    float speed = 2f;
    Quaternion pos;
    Rigidbody rb;
    AudioSource source;
    public AudioClip clip;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
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
            if (mesh.enabled)
            {
                source.PlayOneShot(clip);
                mesh.enabled = false;
            }
        }
    }
}

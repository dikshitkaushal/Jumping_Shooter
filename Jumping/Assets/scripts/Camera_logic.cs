using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_logic : MonoBehaviour
{
    public GameObject target;
    public float smoothness_amount = 0.125f;
    public Vector3 offset;
    private void FixedUpdate()
    {
        Vector3 movedposition = target.transform.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, movedposition, smoothness_amount);
        transform.position = smoothposition;
    }
}

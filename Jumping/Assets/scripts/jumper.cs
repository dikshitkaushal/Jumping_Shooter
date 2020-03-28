using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour
{
    public characterScript chars;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        chars.jumpd = 3f;
        chars.isjumping = true;
        StartCoroutine(returnnormal());
        
    }
    IEnumerator returnnormal()
    {
        yield return new WaitForSeconds(1);
        chars.jumpd = 1f;
    }
}

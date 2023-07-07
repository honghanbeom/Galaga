using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireMovement : MonoBehaviour
{
    public Rigidbody tireBody;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        tireBody = GetComponent<Rigidbody>();
        tireBody.velocity = transform.forward * -speed;
        
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

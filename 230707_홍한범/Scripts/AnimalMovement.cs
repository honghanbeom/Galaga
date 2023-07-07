using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimalMovement : MonoBehaviour
{
    public Rigidbody animalBody;
    private float speed;
    public float speedMax = 18f;
    public float speedMin = 12f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody animalBody = GetComponent<Rigidbody>();
        speed = Random.Range(speedMin, speedMax);
        animalBody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAnimal();       
    }

    void DestroyAnimal()
    {
        float tolerance = 0.2f;
        if (Mathf.Abs(transform.position.z + 7) < tolerance)
        {
            Destroy(gameObject);            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Die();
            }
        }
    }
}

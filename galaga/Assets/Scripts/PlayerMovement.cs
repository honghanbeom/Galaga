using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject tirePrefab;
    public Rigidbody playerBody;
    public float speed = 15f;
    public float attackTime = 0.1f;
    public float attackDelay;
    // Start is called before the first frame update
    void Start()
    {
        attackDelay = 0f;
        playerBody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = -speed * xInput;
        Vector3 playerVector = new Vector3(xSpeed, 0f, 0f);
        playerBody.velocity = playerVector;


        attackDelay += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            if (attackDelay >= attackTime)
            {
                attackDelay = 0f;
                GameObject Tire = Instantiate(tirePrefab, transform.position,
                   transform.rotation);
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        
        GameManger gameManger = FindObjectOfType<GameManger>();
        gameManger.EndGame();
    }


        



}

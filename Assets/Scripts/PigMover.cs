using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PigMover : MonoBehaviour
{
    
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private GameObject block1;
    [SerializeField] private GameObject block2;
    [SerializeField] private GameObject portal;
    private float speed = 5.0f;
    private float horizontalInput;
    private float nextY = -1;
    private float nextX = 5;
    private bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            int randint = Random.Range(0, 2);
            if (randint == 0)
            {
                Instantiate(block1, new Vector3(nextX, nextY, 0), transform.rotation);
                nextX = nextX + 5;
                nextY = nextY + Random.Range(0, 2) * 2 - 1;
            }
            else if (randint == 1)
            {
                Instantiate(block2, new Vector3(nextX, nextY, 0), transform.rotation);
                nextX = nextX + 7;
                nextY = nextY + Random.Range(0, 2) * 2 - 1;
            }
        }
        portal.transform.position = new Vector3(nextX, nextY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver==false)
        {
            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                print(Math.Round(myRigidbody.velocity.y));
                if (Math.Round(myRigidbody.velocity.y) == 0)
                {
                    myRigidbody.velocity = Vector3.up * 5;
                }
            }
            horizontalInput = Input.GetAxis("Horizontal");
        
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Portal")
        {
            print("You win");
        }
    }
}

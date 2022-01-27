using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_S : MonoBehaviour
{
    // Move Variables
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public int playerHealth;

    // Wall Checks
    public bool stopRight;
    public bool stopLeft;
    public bool stopForward;
    public bool stopBackward;

    public Animator deathAnim;

    //Had to hard program collision detection because I didn't use rigidbodies
    private void FixedUpdate()
    {
        //Shoots out rays in all 4 directions for wall check
        stopRight = Physics.Raycast(transform.position, Vector3.right, 0.67f);
        stopLeft = Physics.Raycast(transform.position, Vector3.left, 0.67f);
        stopForward = Physics.Raycast(transform.position, Vector3.forward, 0.67f);
        stopBackward = Physics.Raycast(transform.position, Vector3.back, 0.67f);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move along the objects z-axis
        if (!stopForward)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= Vector3.back * speed * Time.deltaTime;
            }
        }
        if (!stopBackward)
        {
            if (Input.GetKey(KeyCode.S) /*&& hitB.transform.tag != "Wall"*/)
            {
                transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
        }


        // move along the objects x-axis
        if (!stopRight)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position -= Vector3.left * speed * Time.deltaTime;
            }
        }
        if (!stopLeft)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    //Player took damage from enemy based off projectile info
    public void TakeDamagePlayer(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0) Invoke(nameof(PlayerDie), 0.5f);
    }
    void PlayerDie()
    {
        deathAnim.SetBool("Dead", true);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLogic_S : MonoBehaviour
{
    public Rigidbody rb;

    public int damageE = 10;
    public int damageP = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks to see what it hit
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyMovement_S>().TakeDamage(damageE);
            Destroy(gameObject);
        }
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerMovement_S>().TakeDamagePlayer(damageP);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup_S : MonoBehaviour
{
    public GameObject scoreManage;

    public GameObject head;
    public GameObject projectileP;
    public float timeRemaining;

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
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.GetComponent<Pickup>().GetPickedUp();
            scoreManage.GetComponent<ScoreManager_S>().scoreTotal += other.gameObject.GetComponent<Pickup>().ScoreValue;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Power Up")
        {
            int type = Random.Range(1, 3);
            if(type == 1)
            {
                head.GetComponent<PlayerAiming_S>().fireWait = Random.Range(0, 3);
                projectileP.GetComponent<projectileLogic_S>().damageE = Random.Range(5, 30);
            }
            if(type == 2)
            {
                gameObject.GetComponent<PlayerMovement_S>().speed = Random.Range(5, 20);
            }

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone_S : MonoBehaviour
{

    public bool enteredTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //player Check
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") enteredTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") enteredTrigger = false;
    }
}

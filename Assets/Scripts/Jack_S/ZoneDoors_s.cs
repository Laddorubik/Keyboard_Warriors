using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDoors_s : MonoBehaviour
{
    bool isRightDoor;
    bool isLeftDoor;
    bool isForwardDoor;
    bool isBackwardDoor;

    public Collider colR;
    public Collider colL;
    public Collider colF;
    public Collider colB;

    public GameObject downBox;
    // Start is called before the first frame update
    void Start()
    {
        downBox = GameObject.Find("downBox");
    }

    // Update is called once per frame
    void Update()
    {
        // Shoots out a raycast in all directions to check if there is a room
        RaycastHit hitR;
        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.right), out hitR, 220))
        {
            if (hitR.collider.gameObject.CompareTag("Room"))
            {
                // if there is a room the collider is enabled letting the player move onto that room
                colR.enabled = true;
            }
            else
            {
                colR.enabled = false;
            }
        }
        RaycastHit hitL;
        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.left), out hitL, 220))
        {
            if (hitL.collider.gameObject.CompareTag("Room"))
            {
                colL.enabled = true;
            }
            else
            {
                colL.enabled = false;
            }
        }
        RaycastHit hitF;
        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.up), out hitF, 350, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hitF.collider.gameObject.CompareTag("Room"))
            {
                colF.enabled = true;
            }
            else
            {
                colF.enabled = false;
            }
        }
        RaycastHit hitB;
        if (Physics.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.down), out hitB, 350, 1 << LayerMask.NameToLayer("Default")))
        { 
            if (hitB.collider.gameObject.CompareTag("Room"))
            {
                colB.enabled = true;
            }
            else
            {
                colB.enabled = false;
            }
        }
    }
}
